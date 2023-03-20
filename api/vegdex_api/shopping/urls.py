from django.urls import include, path

from vegdex_api.common import routers as common_routers

from . import views

router = common_routers.OptionalSlashRouter()
router.register("farmers-markets", views.FarmersMarketViewSet, "farmers-markets")
router.register("vegan-companies", views.VeganCompanyViewSet, "vegan-companies")

urlpatterns = [
    path('', include(router.urls)),
]
