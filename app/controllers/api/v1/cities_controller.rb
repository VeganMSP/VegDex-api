# frozen_string_literal: true

class Api::V1::CitiesController < Api::BaseController
  def index
    @cities = City.all
    render json: @cities, include: :restaurants
  end
end
