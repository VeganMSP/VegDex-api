# == Schema Information
#
# Table name: vegan_companies
#
#  id          :bigint           not null, primary key
#  name        :string
#  slug        :string
#  website     :string
#  description :text
#  created_at  :datetime         not null
#  updated_at  :datetime         not null
#
class VeganCompany < ApplicationRecord
end
