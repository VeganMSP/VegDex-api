# frozen_string_literal: true

class CreateBlogPosts < ActiveRecord::Migration[7.0]
  def change
    create_table :blog_posts do |t|
      t.string :title
      t.text :content
      t.string :slug
      t.integer :status
      t.references :blog_post_category, null: false, foreign_key: true

      t.timestamps
    end
    add_index :blog_posts, :slug, unique: true
  end
end
