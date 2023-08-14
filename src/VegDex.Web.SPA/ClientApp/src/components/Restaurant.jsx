import React, {Component} from "react";
import PropTypes from "prop-types";

export class Restaurant extends Component {
	static propTypes = {
		restaurant: PropTypes.object
	};

	render() {
		const {restaurant} = this.props;

		let restaurant_name;
		if (restaurant.website === "") {
			restaurant_name = restaurant.name;
		} else {
			restaurant_name = <RestaurantLink
				key={restaurant.slug}
				restaurant={restaurant}/>;
		}

		return (
			<li key={restaurant.name}>
				{restaurant_name} - {restaurant.description}
			</li>
		);
	}
}

export class RestaurantLink extends Component {
	static propTypes = {
		restaurant: PropTypes.object
	};

	render() {
		const {name, website, all_vegan} = this.props.restaurant;

		if (!all_vegan && website === "") {
			return (
				{name}
			);
		} else if (all_vegan && website === "") {
			return (
				<strong>{name}</strong>
			);
		} else if (!all_vegan && website !== "") {
			return (
				<a href={website}>{name}</a>
			);
		} else if (all_vegan && website !== "") {
			return (
				<a href={website}><strong>{name}</strong></a>
			);
		}

	}
}