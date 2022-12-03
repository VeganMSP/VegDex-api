# frozen_string_literal: true

class Api::V1::BlogPostCategoriesController < Api::BaseController
  def index
    @blog_post_categories = BlogPostCategory.all
    render json: @blog_post_categories
  end

  def create
    blog_post_category = BlogPostCategory.create(blog_post_category_params)
    Rails.logger.info blog_post_category.errors.full_messages
    render json: blog_post_category
  end

  def destroy
    BlogPostCategory.destroy(params[:id])
  end

  def update
    blog_post_category = BlogPostCategory.find(params[:id])
    blog_post_category.update(blog_post_category_params)
    render json: blog_post_category
  end

  private

  def blog_post_category_params
    params.require(:blog_post_category).permit(:id, :name)
  end
end
