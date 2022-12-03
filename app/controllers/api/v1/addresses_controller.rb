# frozen_string_literal: true

class Api::V1::AddressesController < Api::BaseController
  def index
    @addresses = Address.all
    render json: @addresses
  end
end
