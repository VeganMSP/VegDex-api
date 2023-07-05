import React, {Component} from 'react';

export class About extends Component<any, any> {
	static displayName = About.name;

	constructor(props: any) {
		super(props);
		this.state = {restaurants: [], loading: true};
	}

	render() {
		return (
			<div>
				<h2>{About.displayName}</h2>
				TODO
			</div>
		);
	}
}