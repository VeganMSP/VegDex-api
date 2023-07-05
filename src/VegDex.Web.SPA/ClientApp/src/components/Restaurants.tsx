import React, {Component} from 'react';
import {City} from './City'
import {ICity} from '../models/ICity';

interface IState {
	restaurants_by_city: ICity[];
	loading: boolean;
}

export class Restaurants extends Component<any, IState> {
	static displayName = Restaurants.name;

	constructor(props: any) {
		super(props);
		this.state = {restaurants_by_city: [], loading: true};
	}

	componentDidMount() {
		this.populateRestaurantsByCity();
	}

	static renderRestaurantsList(restaurants_by_city: ICity[]) {
		return (
			<div>
				{restaurants_by_city.map(city =>
					<City
						key={city.slug}
						city={city}
						restaurants={city.restaurants}
					/>)}
			</div>
		);
	}

	static renderCityList(restaurants_by_city: ICity[]) {
		return (
			<div>
				Jump to city:
				<ul>
					{restaurants_by_city.map(city =>
						<li key={city.slug}><a href={'#' + city.slug}>{city.name}</a></li>
					)}
				</ul>
			</div>
		)
	}

	render() {
		let contents = this.state.loading
			? <p><em>Loading...</em></p>
			: Restaurants.renderRestaurantsList(this.state.restaurants_by_city);
		let city_list = this.state.loading
			? <p><em>Loading...</em></p>
			: Restaurants.renderCityList(this.state.restaurants_by_city);

		return (
			<div>
				<h2>Restaurants</h2>
				{city_list}
				{contents}
			</div>
		);
	}

	async populateRestaurantsByCity() {
		const response = await fetch('api/v1/cities-with-restaurants');
		const data = await response.json();
		this.setState({restaurants_by_city: data, loading: false});
	}
}