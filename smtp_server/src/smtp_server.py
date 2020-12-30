import logging

from asyncio import AbstractEventLoop
from aiosmtpd.smtp import SMTP
from email import message_from_bytes
from hashlib import md5

from src import MessageManager


class SMTPServer:
    def __init__(self,
                 host: str,
                 port: int,
                 next_hop: str,
                 loop: AbstractEventLoop):
        self.host = host
        self.port = port
        self.loop = loop
        self.next_hop = next_hop
        self.server = None

    def get_server(self):
        return SMTP(
            handler=self,
            hostname=self.host,
            enable_SMTPUTF8=True,
            loop=self.loop,
        )

    async def start(self):
        self.server = await self.loop.create_server(
            self.get_server,
            host=self.host,
            port=self.port,
        )
        logging.info('SMTP server for "%s" started on port %s.' %
                     (self.host, self.port))
        return self.server

    def close(self):
        self.server.close()
        logging.info('SMTP server for "%s" stopped.' % self.host)

    async def handle_DATA(self, protocol, session, envelope):
        envelope_hash = md5(envelope.content).hexdigest()
        msg = message_from_bytes(envelope.original_content)
        message_id = msg['Message-ID'] or envelope_hash
        logging.info(f'Received a message: {message_id}')
        msg_process_task = self.loop.create_task(
            MessageManager.post_msg_by_http(msg, self.next_hop))
        msg_process_task.add_done_callback(
            lambda t: logging.info(f'Message {message_id} has been processed'))
        return '250 OK'
