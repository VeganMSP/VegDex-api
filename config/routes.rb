# frozen_string_literal: true

Rails.application.routes.draw do
  namespace :links do
    get 'link_categories/create'
  end
  namespace :admin do
    resources :addresses
    resources :cities
    resources :farmers_markets
    resources :links
    resources :link_categories
    resources :restaurants
    resources :blog_posts
    resources :blog_post_categories

    root to: 'addresses#index'
  end

  namespace :api do
    namespace :v1 do
      resources :restaurants, only: %i[index]
      resources :farmers_markets, only: %i[index]
      resources :cities, only: %i[index]
      resources :addresses, only: %i[index]
      resources :locations, only: %i[index]
      resources :links_by_category, only: %i[index]
      resources :link_categories, only: %i[index create destroy update]
      resources :links, only: %i[index create destroy update]
      resources :vegan_companies, only: %i[index]
      resources :farmers_markets, only: %i[index]
      resources :blog_posts_by_category, only: %i[index]
      resources :blog_posts, only: %i[index create destroy update]
    end
  end

  get 'restaurants', to: 'home#index'
  get 'shopping', to: 'home#index'
  get 'links', to: 'home#index'
  get 'blog', to: 'home#index'
  get 'blog/:year/:month/:day/:slug', to: 'home#index'
  get 'about', to: 'home#index'

  root 'home#index'
end
