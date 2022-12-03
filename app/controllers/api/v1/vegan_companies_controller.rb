# frozen_string_literal: true

class Api::V1::VeganCompaniesController < Api::BaseController
  def index
    @vegan_companies = VeganCompany.all
    render json: @vegan_companies
  end
end
