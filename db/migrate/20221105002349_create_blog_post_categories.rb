# frozen_string_literal: true

class CreateBlogPostCategories < ActiveRecord::Migration[7.0]
  def change
    create_table :blog_post_categories do |t|
      t.string :name
      t.string :slug

      t.timestamps
    end
    add_index :blog_post_categories, :slug, unique: true
  end
end
