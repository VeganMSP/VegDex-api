# frozen_string_literal: true

class Api::V1::LinksController < ApplicationController
  def index
    @links = Link.all
    render json: @links
  end
end
