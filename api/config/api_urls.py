from django.urls import include, path

from vegdex_api.common import routers as common_routers
from vegdex_api.common import views as common_views
from vegdex_api.restaurants import views as restaurants_views


router = common_routers.OptionalSlashRouter()
router.register("addresses", common_views.AddressViewSet, "addresses")
router.register("cities", common_views.CityViewSet, "cities")
router.register("cities_with_restaurants", common_views.CityWithRestaurantsViewSet, "cities-with-restaurants")
router.register("restaurants", restaurants_views.RestaurantViewSet, "restaurants")
v1_patterns = router.urls

urlpatterns = [
    path("v1/", include((v1_patterns, "v1"), namespace="v1"))
]
