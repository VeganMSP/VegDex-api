# frozen_string_literal: true

class Api::V1::CitiesController < ApplicationController
  def index
    @cities = City.all
    render json: @cities, include: :restaurants
  end
end
