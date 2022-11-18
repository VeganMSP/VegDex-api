# frozen_string_literal: true

# == Schema Information
#
# Table name: restaurants
#
#  id          :bigint           not null, primary key
#  name        :string
#  city_id     :bigint           not null
#  slug        :string
#  website     :string
#  description :text
#  all_vegan   :boolean
#  created_at  :datetime         not null
#  updated_at  :datetime         not null
#
class Restaurant < ApplicationRecord
  belongs_to :city

  validates :name, presence: true
  validates :description, presence: true

  def city_name
    city
  end
end
