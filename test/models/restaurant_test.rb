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
require "test_helper"

class RestaurantTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
