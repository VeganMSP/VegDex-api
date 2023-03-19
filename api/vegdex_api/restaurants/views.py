from rest_framework import viewsets
# from rest_framework.response import Response

from . import models, serializers


class RestaurantViewSet(viewsets.ModelViewSet):
    serializer_class = serializers.RestaurantSerializer
    queryset = models.Restaurant.objects.all()

    # def list(self, request, *args, **kwargs):
    #     restuarant = utils.get_restaurant()
    #     serializer = self.serializer_class(restaurant, many=True)
    #     return Response({"results": serializer.data}, status=200)
