# frozen_string_literal: true

class Api::V1::RestaurantsController < Api::BaseController
  def index
    @restaurants = Restaurant.all
    render json: @restaurants, include: :city
  end
end
