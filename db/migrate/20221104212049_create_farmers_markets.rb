class CreateFarmersMarkets < ActiveRecord::Migration[7.0]
  def change
    create_table :farmers_markets do |t|
      t.references :address, null: false, foreign_key: true
      t.text :hours
      t.string :name
      t.string :slug
      t.string :phone
      t.string :website

      t.timestamps
    end
  end
end
