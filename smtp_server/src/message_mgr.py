from email.message import Message

from src import AioHTTPClient


class MessageManager:

    @staticmethod
    async def post_msg_by_http(msg: Message, host):
        message = {'MessageId': f'{msg["message-id"]}',
                   'Subject': msg['Subject'],
                   'From': msg['From'],
                   'To': msg['To'],
                   'Content': msg.get_payload(),
                   'Timestamp': msg['Date']}
        http_client = AioHTTPClient(host)
        await http_client.request('POST', payload=message)


