from django.db import models
from django.utils.text import slugify

from vegdex_api.common.models import CustomModel, Address


class FarmersMarket(CustomModel):
    address = models.ForeignKey(Address, on_delete=models.CASCADE)
    hours = models.TextField(blank=True)
    name = models.CharField(max_length=200)
    slug = models.SlugField(
        max_length=200,
        editable=False,
        unique=True
    )
    phone = models.CharField(max_length=20, blank=True)
    website = models.CharField(max_length=2000, blank=True)

    def __str__(self):
        return self.name

    def save(self, *args, **kwargs):
        value = self.name
        self.slug = slugify(value, allow_unicode=True)
        super().save(*args, **kwargs)


class VeganCompany(CustomModel):
    name = models.CharField(max_length=200)
    slug = models.SlugField(
        unique=True,
        editable=False,
    )
    website = models.CharField(max_length=2000, blank=True)
    description = models.TextField(blank=True)

    def __str__(self):
        return self.name

    def save(self, *args, **kwargs):
        value = self.name
        self.slug = slugify(value, allow_unicode=True)
        super().save(*args, **kwargs)

    class Meta:
        verbose_name_plural = "vegan companies"
