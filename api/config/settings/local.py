from .common import *  # noqa
from pathlib import Path

# Quick-start development settings - unsuitable for production
# See https://docs.djangoproject.com/en/4.1/howto/deployment/checklist/

# SECURITY WARNING: keep the secret key used in production secret!
SECRET_KEY = 'django-insecure-=y-u(pv5)gxli$#8n!zkb+7g=op!1*f45h_4z+d$4$ot3w#vuy'

DEBUG = env.bool("DJANGO_DEBUG", default=True)

