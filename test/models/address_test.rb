# frozen_string_literal: true

# == Schema Information
#
# Table name: addresses
#
#  id         :bigint           not null, primary key
#  name       :string
#  street1    :string
#  street2    :string
#  city_id    :bigint           not null
#  state      :string
#  zip_code   :string
#  created_at :datetime         not null
#  updated_at :datetime         not null
#
require 'test_helper'

class AddressTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
