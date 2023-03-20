from rest_framework import serializers

from vegdex_api.common import models as common_models
from . import models


class RestaurantSerializer(serializers.ModelSerializer):
    city_id = serializers.PrimaryKeyRelatedField(
        queryset=common_models.City.objects.all(),
        source='location.id'
    )

    class Meta:
        model = models.Restaurant
        fields = ("id", "name", "city_id",
                  "website", "description", "all_vegan")
