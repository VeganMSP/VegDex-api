class Api::V1::BlogPostsByCategoryController < ApplicationController
  def index
    @blog_post_categories = BlogPostCategory.all
    render json: @blog_post_categories, include: :blog_posts
  end
end
