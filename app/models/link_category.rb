# frozen_string_literal: true

# == Schema Information
#
# Table name: link_categories
#
#  id          :bigint           not null, primary key
#  name        :string
#  slug        :string
#  description :text
#  created_at  :datetime         not null
#  updated_at  :datetime         not null
#
class LinkCategory < ApplicationRecord
  has_many :links
  validates :slug, uniqueness: true

  slug :name
end
