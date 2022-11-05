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
require "test_helper"

class LinkTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
