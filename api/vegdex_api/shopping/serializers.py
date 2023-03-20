from rest_framework import serializers

from . import models
from ..common.serializers import AddressSerializer


class FarmersMarketSerializer(serializers.ModelSerializer):
    address = AddressSerializer(read_only=True)

    class Meta:
        model = models.FarmersMarket
        fields = ("id", "name", "slug", "phone", "website", "address")


class VeganCompanySerializer(serializers.ModelSerializer):
    class Meta:
        model = models.VeganCompany
        fields = ("id", "name", "slug", "description", "website")
