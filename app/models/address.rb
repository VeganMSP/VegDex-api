# == Schema Information
#
# Table name: addresses
#
#  id         :bigint           not null, primary key
#  name       :string
#  street1    :string
#  street2    :string
#  city_id    :bigint           not null
#  state      :string
#  zip_code   :string
#  created_at :datetime         not null
#  updated_at :datetime         not null
#
class Address < ApplicationRecord
  belongs_to :city
  has_many :farmers_markets
end
