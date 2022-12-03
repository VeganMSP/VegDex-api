# frozen_string_literal: true

class Api::V1::LinkCategoriesController < ApplicationController
  def index
    @link_categories = LinkCategory.all
    render json: @link_categories
  end

  def create
    link_category = LinkCategory.create(link_category_params)
    puts link_category.errors.full_messages
    render json: link_category
  end

  def destroy
    LinkCategory.destroy(params[:id])
  end

  def update
    link_category = LinkCategory.find(params[:id])
    link_category.update(link_category_params)
    render json: link_category
  end

  private
  def link_category_params
    params.require(:link_category).permit(:id, :name, :description)
  end
end
