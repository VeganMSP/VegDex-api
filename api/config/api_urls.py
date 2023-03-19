from django.urls import include, path

from vegdex_api.common import routers as common_routers
from vegdex_api.restaurants import views as restaurants_views


router = common_routers.OptionalSlashRouter()
router.register("restaurants", restaurants_views.RestaurantViewSet, "restaurants")
v1_patterns = router.urls

urlpatterns = [
    path("v1/", include((v1_patterns, "v1"), namespace="v1"))
]
