# frozen_string_literal: true

class Api::V1::BlogPostsController < Api::BaseController
  def index
    if params[:slug]
      show
      return
    end
    render json: BlogPost.all, include: :blog_post_category
  end

  def show
    if params[:slug]
      post = BlogPost.find_by slug: params[:slug]
      Rails.logger.info json: post
      render json: post
    end
  end

  def create
    post = BlogPost.create(post_params)
    Rails.logger.info json: post
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
