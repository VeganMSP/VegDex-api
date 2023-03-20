from django.db import models
from django.utils.text import slugify
from mptt.fields import TreeForeignKey
from mptt.models import MPTTModel

from vegdex_api.common.models import CustomModel


class LinkCategory(MPTTModel, CustomModel):
    name = models.CharField(max_length=200)
    slug = models.SlugField(
        unique=True,
        editable=False,
    )
    description = models.TextField(blank=True)
    parent = TreeForeignKey(
        'self',
        blank=True,
        null=True,
        related_name='child',
        on_delete=models.CASCADE
    )

    class Meta:
        unique_together = ('slug', 'parent',)
        verbose_name_plural = "link categories"

    def __str__(self):
        full_path = [self.name]
        k = self.parent
        while k is not None:
            full_path.append(k.name)
            k = k.parent

        return ' -> '.join(full_path[::-1])

    def get_name(self):
        return self.name

    def save(self, *args, **kwargs):
        slug = self.name
        self.slug = slugify(slug, allow_unicode=True)
        super().save(*args, **kwargs)


class Link(CustomModel):
    name = models.CharField(max_length=200)
    slug = models.SlugField(
        max_length=200,
        editable=False,
        unique=True
    )
    website = models.CharField(max_length=200)
    description = models.TextField(blank=True)
    category = models.ForeignKey(
        LinkCategory,
        related_name='links',
        on_delete=models.CASCADE
    )

    def __str__(self):
        return self.name

    def save(self, *args, **kwargs):
        value = self.name
        self.slug = slugify(value, allow_unicode=True)
        super().save(*args, **kwargs)
