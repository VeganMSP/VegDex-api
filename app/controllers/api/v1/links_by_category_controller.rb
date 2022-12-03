# frozen_string_literal: true

class Api::V1::LinksByCategoryController < Api::BaseController
  def index
    @categories = LinkCategory.all
    render json: @categories, include: :links
  end
end
