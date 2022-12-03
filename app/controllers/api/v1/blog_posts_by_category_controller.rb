# frozen_string_literal: true

class Api::V1::BlogPostsByCategoryController < Api::BaseController
  def index
    @blog_post_categories = BlogPostCategory.all
    render json: @blog_post_categories, include: :blog_posts
  end
end
