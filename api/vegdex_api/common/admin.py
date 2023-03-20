from django.contrib import admin

from .models import City, Address


class CityAdmin(admin.ModelAdmin):
    list_display = ('name', 'date_updated', 'date_created')
    search_fields = ['name', 'description']


admin.site.register(City, CityAdmin)
admin.site.register(Address)
