# frozen_string_literal: true

class Api::V1::LinksByCategoryController < ApplicationController
  def index
    @categories = LinkCategory.all
    render json: @categories, include: :links
  end
end
