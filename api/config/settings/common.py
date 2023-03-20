import logging.config

import environ

logger = logging.getLogger("vegdex_api.config")
ROOT_DIR = environ.Path(__file__) - 3
APPS_DIR = ROOT_DIR.path("vegdex_api")

env = environ.Env()
ENV = env
LOGLEVEL = env("LOGLEVEL", default="info").upper()
"""
Default logging level for the VegDex processes"""  # pylint: disable=W0105

LOGGING_CONFIG = None
logging.config.dictConfig(
    {
        "version": 1,
        "disable_existing_loggers": False,
        "formatters": {
            "console": {"format": "%(asctime)s %(name)-12s %(levelname)-8s %(message)s"}
        },
        "handlers": {
            "console": {"class": "logging.StreamHandler", "formatter": "console"},
        },
        "loggers": {
            "vegdex_api": {
                "level": LOGLEVEL,
                "handlers": ["console"],
                # required to avoid double logging with root logger
                "propagate": False,
            },
            "plugins": {
                "level": LOGLEVEL,
                "handlers": ["console"],
                # required to avoid double logging with root logger
                "propagate": False,
            },
            "environ": {
                "level": LOGLEVEL,
                "handlers": ["console"],
                "propagate": False,
            },
            "": {"level": "WARNING", "handlers": ["console"]},
        },
    }
)

ENV_FILE = env_file = env("ENV_FILE", default=None)
"""
Path to a .env file to load
"""
if env_file:
    logger.info("Loading specified env file at %s", env_file)
    env.read_env(env_file)
else:
    # Try to load from .env and config/.env
    # but don't crash if those aren't found
    paths = [
        ROOT_DIR,
        ((ROOT_DIR - 1).path("config")),
    ]
    for path in paths:
        try:
            env_path = path.file(".env")
        except FileNotFoundError:
            continue
        env.read_env(env_path)
        break

# Custom Admin URL, use {% url 'admin:index' %}
ADMIN_URL = env("DJANGO_ADMIN_URL", default="api/admin/")
"""
Path to the Django admin area.

Examples:

- ``api/admin/``
- ``api/mycustompath/``

"""
ALLOWED_HOSTS = []

# Application definition

INSTALLED_APPS = [
    'django.contrib.admin',
    'django.contrib.auth',
    'django.contrib.contenttypes',
    'django.contrib.sessions',
    'django.contrib.messages',
    'django.contrib.staticfiles',

    'corsheaders',
    'rest_framework',

    'vegdex_api.common',
    'vegdex_api.restaurants',
    'vegdex_api.shopping',
]

MIDDLEWARE = [
    'django.middleware.security.SecurityMiddleware',
    'django.contrib.sessions.middleware.SessionMiddleware',
    'django.middleware.common.CommonMiddleware',
    'django.middleware.csrf.CsrfViewMiddleware',
    'django.contrib.auth.middleware.AuthenticationMiddleware',
    'django.contrib.messages.middleware.MessageMiddleware',
    'django.middleware.clickjacking.XFrameOptionsMiddleware',
    'corsheaders.middleware.CorsMiddleware',
]

CORS_ORIGIN_WHITELIST = [
    'http://localhost:3000'
]

ROOT_URLCONF = 'config.urls'

TEMPLATES = [
    {
        'BACKEND': 'django.template.backends.django.DjangoTemplates',
        'DIRS': [],
        'APP_DIRS': True,
        'OPTIONS': {
            'context_processors': [
                'django.template.context_processors.debug',
                'django.template.context_processors.request',
                'django.contrib.auth.context_processors.auth',
                'django.contrib.messages.context_processors.messages',
            ],
        },
    },
]

WSGI_APPLICATION = 'config.wsgi.application'


# Database
# https://docs.djangoproject.com/en/4.1/ref/settings/#databases

DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.sqlite3',
        'NAME': str(ROOT_DIR.path('db.sqlite3')),
    }
}


# Password validation
# https://docs.djangoproject.com/en/4.1/ref/settings/#auth-password-validators

AUTH_PASSWORD_VALIDATORS = [
    {
        'NAME': 'django.contrib.auth.password_validation.UserAttributeSimilarityValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.MinimumLengthValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.CommonPasswordValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.NumericPasswordValidator',
    },
]


# Internationalization
# https://docs.djangoproject.com/en/4.1/topics/i18n/

LANGUAGE_CODE = 'en-us'

TIME_ZONE = 'UTC'

USE_I18N = True

USE_TZ = True


# Static files (CSS, JavaScript, Images)
# https://docs.djangoproject.com/en/4.1/howto/static-files/

STATIC_URL = 'static/'

# Default primary key field type
# https://docs.djangoproject.com/en/4.1/ref/settings/#default-auto-field

DEFAULT_AUTO_FIELD = 'django.db.models.BigAutoField'
