from rest_framework import viewsets

from . import models, serializers


class FarmersMarketViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.FarmersMarketSerializer
    queryset = models.FarmersMarket.objects.all()


class VeganCompanyViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.VeganCompanySerializer
    queryset = models.VeganCompany.objects.all()
