from django.db import models
from django.utils.text import slugify


class CustomModel(models.Model):
    def is_deletable(self):
        # get all the related objects
        for rel in self._meta.get_fields():
            try:
                # check if there is a relationship with at least one
                # related object
                related = rel.related_model.objects.filter(
                    **{rel.field.name: self}
                )
                if related.exists():
                    # if there is, return a tuple of flag = False and
                    # the related_model object
                    return False, related
            except AttributeError:
                # an attribute error for field occurs when checking for
                # AutoField. Just pass as we don't need to check for
                # AutoField
                pass
        return True, None

    class Meta:
        abstract = True


class City(CustomModel):
    name = models.CharField(max_length=200)
    slug = models.SlugField(
        unique=True,
        editable=False,
    )
    date_created = models.DateTimeField(auto_now_add=True)
    date_updated = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.name

    def save(self, *args, **kwargs):
        value = self.name
        self.slug = slugify(value, allow_unicode=True)
        super().save(*args, **kwargs)

    class Meta:
        verbose_name_plural = "cities"


class Address(CustomModel):
    name = models.CharField(max_length=200, blank=True)
    street1 = models.CharField(max_length=200, blank=True)
    street2 = models.CharField(max_length=200, blank=True)
    city = models.ForeignKey(City, on_delete=models.CASCADE)
    state = models.CharField(max_length=2)
    zip_code = models.CharField(max_length=10, blank=True)

    def __str__(self):
        if self.name != "":
            return self.name
        elif self.street1 != "":
            return self.street1 + " - " + self.city.name
        else:
            return self.city.name

    class Meta:
        verbose_name_plural = "addresses"
