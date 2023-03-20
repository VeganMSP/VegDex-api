from rest_framework import serializers

from vegdex_api.restaurants.serializers import RestaurantSerializer
from . import models


class CitySerializer(serializers.ModelSerializer):
    class Meta:
        model = models.City
        fields = ("id", "name", "slug", "date_created", "date_updated")


class CityWithRestaurantsSerializer(CitySerializer):
    restaurants = RestaurantSerializer(many=True, read_only=True)

    class Meta:
        model = models.City
        fields = ("id", "name", "slug",
                  "date_created", "date_updated", "restaurants")


class AddressSerializer(serializers.ModelSerializer):
    class Meta:
        model = models.Address
        fields = ("id", "name", "street1", "street2",
                  "state", "zip_code", "city")
