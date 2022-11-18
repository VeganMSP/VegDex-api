# frozen_string_literal: true

class CreateVeganCompanies < ActiveRecord::Migration[7.0]
  def change
    create_table :vegan_companies do |t|
      t.string :name
      t.string :slug
      t.string :website
      t.text :description

      t.timestamps
    end
    add_index :vegan_companies, :slug, unique: true
  end
end
