# frozen_string_literal: true

class Api::V1::RestaurantsController < ApplicationController
  def index
    @restaurants = Restaurant.all
    render json: @restaurants, include: :city
  end
end
