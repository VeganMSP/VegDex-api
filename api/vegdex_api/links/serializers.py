from rest_framework import serializers

from . import models


class LinkCategorySerializer(serializers.ModelSerializer):
    class Meta:
        model = models.LinkCategory
        fields = ("id", "name", "slug", "description", "parent")


class LinkSerializer(serializers.ModelSerializer):
    category = LinkCategorySerializer(read_only=True)

    class Meta:
        model = models.Link
        fields = ("id", "name", "slug", "website", "description", "category")


class LinkCategoryWithLinksSerializer(serializers.ModelSerializer):
    links = LinkSerializer(many=True, read_only=True)

    class Meta:
        model = models.LinkCategory
        fields = ("id", "name", "slug", "description", "parent", "links")
