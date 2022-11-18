# frozen_string_literal: true

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
class BlogPostCategory < ApplicationRecord
  has_many :blog_posts
  slug :name
end
