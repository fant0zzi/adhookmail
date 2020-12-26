import aiohttp
import asyncio
import logging
import urllib

HEADERS = {"Content-Type": "application/json"}


class AioHTTPClient:
    def __init__(self, base_url: str):
        self.base_url = base_url

    async def request(self,
                      method: str,
                      endpoint: str = '',
                      payload: dict = None,
                      **kwargs):
        for key, item in kwargs.items():
            if type(item) is str:
                kwargs[key] = urllib.parse.quote(item)
        url = self.base_url + endpoint.format(**kwargs)
        async with aiohttp.ClientSession() as session:
            request = getattr(session, method.lower())
            async with request(url,
                               json=payload,
                               headers=HEADERS):
                try:
                    logging.info(f'{method} {url} {payload}')
                except Exception as e:
                    logging.info(f'Could not execute {method} request by {url} '
                                 f'Exception: {e}')

    def execute(self, method: str,
                endpoint: str,
                payload=None,
                **kwargs):
        loop = asyncio.get_event_loop()
        loop.run_until_complete(
            self.request(method, endpoint, payload, **kwargs))
        loop.close()




