class Api::V1::BlogPostsController < ApplicationController
  def index
    @blog_posts = BlogPost.all
    render json: @blog_posts, include: :blog_post_category
  end
end

