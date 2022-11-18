# frozen_string_literal: true

class CreateRestaurants < ActiveRecord::Migration[7.0]
  def change
    create_table :restaurants do |t|
      t.string :name
      t.references :city, null: false, foreign_key: true
      t.string :slug
      t.string :website
      t.text :description
      t.boolean :all_vegan

      t.timestamps
    end
  end
end
