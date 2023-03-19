from rest_framework import serializers

from . import models


class RestaurantSerializer(serializers.ModelSerializer):
    class Meta:
        model = models.Restaurant
        fields = ("id", "name", "location", "website", "description", "all_vegan")
