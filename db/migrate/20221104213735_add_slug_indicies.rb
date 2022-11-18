# frozen_string_literal: true

class AddSlugIndicies < ActiveRecord::Migration[7.0]
  def change
    add_index :restaurants, :slug, unique: true
    add_index :farmers_markets, :slug, unique: true
    add_index :link_categories, :slug, unique: true
    add_index :links, :slug, unique: true
  end
end
