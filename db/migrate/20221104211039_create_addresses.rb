# frozen_string_literal: true

class CreateAddresses < ActiveRecord::Migration[7.0]
  def change
    create_table :addresses do |t|
      t.string :name
      t.string :street1
      t.string :street2
      t.references :city, null: false, foreign_key: true
      t.string :state
      t.string :zip_code

      t.timestamps
    end
  end
end
