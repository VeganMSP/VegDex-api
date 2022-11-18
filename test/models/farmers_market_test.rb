# frozen_string_literal: true

# == Schema Information
#
# Table name: farmers_markets
#
#  id         :bigint           not null, primary key
#  address_id :bigint           not null
#  hours      :text
#  name       :string
#  slug       :string
#  phone      :string
#  website    :string
#  created_at :datetime         not null
#  updated_at :datetime         not null
#
require 'test_helper'

class FarmersMarketTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
