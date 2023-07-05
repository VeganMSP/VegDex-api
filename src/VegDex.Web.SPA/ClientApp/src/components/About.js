import React, {Component} from 'react';

export class About extends Component {
	static displayName = About.name;

	constructor(props) {
		super(props);
		this.state = {restaurants: [], loading: true};
	}

	render() {
		return (
			<div>
				<h2>{this.displayName}</h2>
				TODO
			</div>
		);
	}
}