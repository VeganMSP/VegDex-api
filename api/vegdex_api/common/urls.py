from django.urls import include, path

from vegdex_api.common import routers as common_routers
from vegdex_api.common import views as common_views

router = common_routers.OptionalSlashRouter()
router.register("addresses", common_views.AddressViewSet, "addresses")
router.register("cities", common_views.CityViewSet, "cities")
router.register("cities-with-restaurants",
                common_views.CityWithRestaurantsViewSet,
                "cities-with-restaurants")

urlpatterns = [
    path('', include(router.urls)),
]
