from django.urls import include, path

from vegdex_api.common import routers as common_routers
from vegdex_api.links import views as links_views
from vegdex_api.restaurants import views as restaurants_views

router = common_routers.OptionalSlashRouter()
router.register("restaurants",
                restaurants_views.RestaurantViewSet, "restaurants")
router.register("links", links_views.LinkViewSet, "links")
router.register("link-categories",
                links_views.LinkCategoryViewSet, "link-categories")
router.register("links-by-category",
                links_views.LinksByCategoryViewSet, "links-by-category")
v1_patterns = router.urls

v1_patterns += [
    path("shopping/", include(("vegdex_api.shopping.urls", "shopping"),
                              namespace="shopping")),
    path("", include(('vegdex_api.common.urls', "common"), namespace="common"))
]

urlpatterns = [
    path("v1/", include((v1_patterns, "v1"), namespace="v1"))
]
