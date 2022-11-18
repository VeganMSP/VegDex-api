# frozen_string_literal: true

# == Schema Information
#
# Table name: cities
#
#  id         :bigint           not null, primary key
#  name       :string
#  slug       :string
#  created_at :datetime         not null
#  updated_at :datetime         not null
#
class City < ApplicationRecord
  has_many :addresses
  has_many :restaurants

  slug :name
end
