# frozen_string_literal: true

# == Schema Information
#
# Table name: blog_posts
#
#  id                    :bigint           not null, primary key
#  title                 :string
#  content               :text
#  slug                  :string
#  status                :integer
#  blog_post_category_id :bigint           not null
#  created_at            :datetime         not null
#  updated_at            :datetime         not null
#
require 'test_helper'

class BlogPostTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
