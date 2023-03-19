from django.db import models
from django.utils.text import slugify

from vegdex_api.generic.models import CustomModel, City


class Restaurant(CustomModel):
    name = models.CharField(max_length=200)
    location = models.ForeignKey(City, on_delete=models.CASCADE)
    date_created = models.DateTimeField('date_published', auto_now_add=True)
    date_updated = models.DateTimeField(auto_now=True)
    slug = models.SlugField(
        max_length=200,
        editable=False,
        unique=True
    )
    website = models.CharField(blank=True, max_length=2000)
    description = models.TextField(blank=True)
    all_vegan = models.BooleanField(default=False)

    def __str__(self):
        return self.name

    def save(self, *args, **kwargs):
        value = self.name
        self.slug = slugify(value, allow_unicode=True)
        super().save(*args, **kwargs)

