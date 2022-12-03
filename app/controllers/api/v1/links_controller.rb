# frozen_string_literal: true

class Api::V1::LinksController < Api::BaseController
  def index
    @links = Link.all
    render json: @links
  end

  def create
    link = Link.create(link_params)
    Rails.logger.info link.errors.full_messages
    render json: link
  end

  def destroy
    Link.destroy(params[:id])
  end

  def update
    link = Link.find(params[:id])
    link.update(link_params)
    render json: link
  end

  private

  def link_params
    params.require(:link).permit(:id, :name, :website, :description, :link_category_id)
  end
end
