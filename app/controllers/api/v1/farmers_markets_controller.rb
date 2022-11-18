# frozen_string_literal: true

class Api::V1::FarmersMarketsController < ApplicationController
  def index
    @farmers_markets = FarmersMarket.all
    render json: @farmers_markets, include: :address
  end
end
