# frozen_string_literal: true

# == Schema Information
#
# Table name: links
#
#  id               :bigint           not null, primary key
#  name             :string
#  slug             :string
#  website          :string
#  description      :text
#  link_category_id :bigint           not null
#  created_at       :datetime         not null
#  updated_at       :datetime         not null
#
class Link < ApplicationRecord
  belongs_to :link_category
  slug :name
end
