# frozen_string_literal: true

class Api::V1::LocationsController < Api::BaseController
  def index
    @locations = Location.all
    render json: @locations
  end
end
