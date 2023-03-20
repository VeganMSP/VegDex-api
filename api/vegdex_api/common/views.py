from django.shortcuts import render
from rest_framework import viewsets

from . import models, serializers


class CityViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.CitySerializer
    queryset = models.City.objects.all()


class CityWithRestaurantsViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.CityWithRestaurantsSerializer
    queryset = models.City.objects.all()


class AddressViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.AddressSerializer
    queryset = models.Address.objects.all()
