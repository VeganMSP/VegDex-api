import React, {Component} from 'react';

export class Home extends Component {
	static displayName = Home.name;

	render() {
		return (
			<>
				<p>Welcome to VeganMSP.com!</p>

				<p>It&apos;s easy being vegan in Minneapolis and St. Paul, but it can be hard to know where to start, or where to
					look for information and answers. We aim to fix that.</p>

				<p>At VeganMSP.com, you will find restaurant and food guides, shopping guides, and other information to help you
					on your vegan journey.</p>
			</>
		);
	}
}