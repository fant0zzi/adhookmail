import asyncio
import logging
import logging.config
import multiprocessing
import signal

from functools import partial
from src import SMTPServer, LOGGING_CONFIG, SMTP_CONFIG

logging.config.dictConfig(LOGGING_CONFIG)
termination_signals = (signal.SIGINT, signal.SIGTERM,)


def main():
    logging.info('Starting...')
    loop = asyncio.get_event_loop()
    loop.set_exception_handler(exceptions_handler)

    server = SMTPServer(host=SMTP_CONFIG['host'],
                        port=SMTP_CONFIG['port'],
                        next_hop=SMTP_CONFIG['next_hop'],
                        loop=loop)

    _shutdown = partial(shutdown, server, loop)
    for signum in termination_signals:
        try:
            loop.add_signal_handler(signum, _shutdown)
        except NotImplementedError:
            signal.signal(signum, _shutdown)

    try:
        loop.run_until_complete(start_server(server))
        loop.run_forever()
    except BaseException as err:
        logging.exception(err)
        raise
    finally:
        _shutdown()


async def start_server(server):
    await server.start()


def exceptions_handler(context):
    logging.exception(str(context))


def shutdown(server, loop, *args):
    for signum in termination_signals:
        try:
            loop.remove_signal_handler(signum)
        except NotImplementedError:
            pass
    server.close()
    logging.info('Servers stopped.')
    loop.create_task(asyncio.sleep(1, loop=loop))
    loop.stop()


class Controller:
    process = None

    def start(self):
        self.process = multiprocessing.Process(target=main)
        self.process.start()

    def stop(self, *args, **kwargs):
        self.process.terminate()


if __name__ == '__main__':
    main()
else:
    smtp_server = Controller()
