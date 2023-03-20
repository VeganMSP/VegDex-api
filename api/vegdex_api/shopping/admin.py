from django.contrib import admin

from .models import (
    FarmersMarket,
    VeganCompany,
)

admin.site.register(FarmersMarket)
admin.site.register(VeganCompany)
