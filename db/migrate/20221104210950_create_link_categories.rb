# frozen_string_literal: true

class CreateLinkCategories < ActiveRecord::Migration[7.0]
  def change
    create_table :link_categories do |t|
      t.string :name
      t.string :slug
      t.text :description

      t.timestamps
    end
  end
end
