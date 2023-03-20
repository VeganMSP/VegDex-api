from django.contrib import admin

from . import models

admin.site.register(models.LinkCategory)
admin.site.register(models.Link)
