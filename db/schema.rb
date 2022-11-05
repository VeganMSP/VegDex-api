# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# This file is the source Rails uses to define your schema when running `bin/rails
# db:schema:load`. When creating a new database, `bin/rails db:schema:load` tends to
# be faster and is potentially less error prone than running all of your
# migrations from scratch. Old migrations may fail to apply correctly if those
# migrations use external dependencies or application code.
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema[7.0].define(version: 2022_11_05_002530) do
  # These are extensions that must be enabled in order to support this database
  enable_extension "plpgsql"

  create_table "addresses", force: :cascade do |t|
    t.string "name"
    t.string "street1"
    t.string "street2"
    t.bigint "city_id", null: false
    t.string "state"
    t.string "zip_code"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["city_id"], name: "index_addresses_on_city_id"
  end

  create_table "blog_post_categories", force: :cascade do |t|
    t.string "name"
    t.string "slug"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["slug"], name: "index_blog_post_categories_on_slug", unique: true
  end

  create_table "blog_posts", force: :cascade do |t|
    t.string "title"
    t.text "content"
    t.string "slug"
    t.integer "status"
    t.bigint "blog_post_category_id", null: false
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["blog_post_category_id"], name: "index_blog_posts_on_blog_post_category_id"
    t.index ["slug"], name: "index_blog_posts_on_slug", unique: true
  end

  create_table "cities", force: :cascade do |t|
    t.string "name"
    t.string "slug"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  create_table "farmers_markets", force: :cascade do |t|
    t.bigint "address_id", null: false
    t.text "hours"
    t.string "name"
    t.string "slug"
    t.string "phone"
    t.string "website"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["address_id"], name: "index_farmers_markets_on_address_id"
    t.index ["slug"], name: "index_farmers_markets_on_slug", unique: true
  end

  create_table "link_categories", force: :cascade do |t|
    t.string "name"
    t.string "slug"
    t.text "description"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["slug"], name: "index_link_categories_on_slug", unique: true
  end

  create_table "links", force: :cascade do |t|
    t.string "name"
    t.string "slug"
    t.string "website"
    t.text "description"
    t.bigint "link_category_id", null: false
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["link_category_id"], name: "index_links_on_link_category_id"
    t.index ["slug"], name: "index_links_on_slug", unique: true
  end

  create_table "restaurants", force: :cascade do |t|
    t.string "name"
    t.bigint "city_id", null: false
    t.string "slug"
    t.string "website"
    t.text "description"
    t.boolean "all_vegan"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["city_id"], name: "index_restaurants_on_city_id"
    t.index ["slug"], name: "index_restaurants_on_slug", unique: true
  end

  create_table "vegan_companies", force: :cascade do |t|
    t.string "name"
    t.string "slug"
    t.string "website"
    t.text "description"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["slug"], name: "index_vegan_companies_on_slug", unique: true
  end

  add_foreign_key "addresses", "cities"
  add_foreign_key "blog_posts", "blog_post_categories"
  add_foreign_key "farmers_markets", "addresses"
  add_foreign_key "links", "link_categories"
  add_foreign_key "restaurants", "cities"
end
