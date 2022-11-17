class Api::V1::BlogPostsController < ApplicationController

  def index
    render json: BlogPost.all, include: :blog_post_category
  end

  def create
    post = BlogPost.create(post_params)
    puts json: post
    render json: post
  end

  def destroy
    BlogPost.destroy(params[:id])
  end

  def update
    post = BlogPost.find(params[:id])
    post.update(post_params)
    render json: post
  end

  private
  def post_params
    params.require(:blog_post).permit(:id, :title, :content, :status, :blog_post_category_id)
  end
end

