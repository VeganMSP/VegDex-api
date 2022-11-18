# frozen_string_literal: true

class CreateLinks < ActiveRecord::Migration[7.0]
  def change
    create_table :links do |t|
      t.string :name
      t.string :slug
      t.string :website
      t.text :description
      t.references :link_category, null: false, foreign_key: true

      t.timestamps
    end
  end
end
