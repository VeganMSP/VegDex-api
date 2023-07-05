import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {ICity} from '../models/ICity';
import {IRestaurant} from '../models/IRestaurant';
import {Restaurant} from './Restaurant';

interface IProps {
	city: ICity;
	restaurants: IRestaurant[];
}

export class City extends Component<IProps> {
	static propTypes = {
		city: PropTypes.object,
		restaurants: PropTypes.array
	}

	render() {
		const {city, restaurants} = this.props;

		return (
			<div>
				<h3 id={city.slug}>{city.name}</h3>
				<ul>
					{restaurants.map(restaurant =>
						<Restaurant
							key={restaurant.slug}
							restaurant={restaurant}/>
					)}
				</ul>
			</div>
		)
	}
}