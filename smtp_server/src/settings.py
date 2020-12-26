SMTP_CONFIG = {'host': '0.0.0.0',
               'port': 11125,
               'next_hop': 'http://message_api:80/api/messages/message'}


LOGGING_CONFIG = {
    'version': 1,
    'formatters': {
        'main_formatter': {
            'format': '%(asctime)s [%(threadName)-12.12s] '
                      '[%(levelname)-5.5s]  %(message)s',
        },
    },
    'handlers': {
        'logfile': {
            'class': 'logging.FileHandler',
            'filename': 'logs',
            'level': 'DEBUG',
        },
        'console': {
            'class': 'logging.StreamHandler',
            'formatter': 'main_formatter',
            'level': 'DEBUG',
        },
    },
    'root': {
        'handlers': ['logfile', 'console'],
        'level': 'DEBUG',
    },
}