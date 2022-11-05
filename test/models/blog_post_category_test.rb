# == Schema Information
#
# Table name: blog_post_categories
#
#  id         :bigint           not null, primary key
#  name       :string
#  slug       :string
#  created_at :datetime         not null
#  updated_at :datetime         not null
#
require "test_helper"

class BlogPostCategoryTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
