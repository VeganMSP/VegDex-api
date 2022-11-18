# frozen_string_literal: true

class Api::V1::LinkCategoriesController < ApplicationController
  def index
    @link_categories = LinkCategory.all
    render json: @link_categories
  end
end
