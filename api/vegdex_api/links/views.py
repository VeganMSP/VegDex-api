from rest_framework import viewsets

from . import models, serializers


class LinkCategoryViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.LinkCategorySerializer
    queryset = models.LinkCategory.objects.all()


class LinkViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.LinkSerializer
    queryset = models.Link.objects.all()


class LinksByCategoryViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.LinkCategoryWithLinksSerializer
    queryset = models.LinkCategory.objects.all()
