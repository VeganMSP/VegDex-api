import React, {Component} from 'react';
import PropTypes from "prop-types";
import NewLink from './_new_link';

export class Links extends Component {
	static displayName = Links.name;

	constructor(props) {
		super(props);
		this.state = {
			links_by_category: [],
			loading: true
		};
	}

	componentDidMount() {
		this.populateLinksByCategory();
	}

	static renderLinksList(links_by_category) {
		return (
			<div>
				{links_by_category.map(category =>
					<LinkCategory
						key={category.slug}
						category={category}
						links={category.links}
					/>)}
			</div>
		);
	}

	render() {
		let contents = this.state.loading
			? <p><em>Loading...</em></p>
			: Links.renderLinksList(this.state.links_by_category);

		return (
			<div>
				<NewLink/>
				<h2>Groups & Links</h2>
				{contents}
			</div>
		);
	}

	async populateLinksByCategory() {
		const response = await fetch('api/v1/links_by_category');
		const data = await response.json();
		this.setState({links_by_category: data, loading: false});
	}
}

export class LinkCategory extends Component {
	static propTypes = {
		category: PropTypes.object,
		links: PropTypes.array
	}

	render() {
		const {category, links} = this.props;

		return (
			<div>
				<h3>{category.name}</h3>
				<ul>
					{links.map(link =>
						<Link key={link.slug} link={link}/>
					)}
				</ul>
			</div>
		)
	}
}

export class Link extends Component {
	static propTypes = {
		link: PropTypes.object,
	}

	render() {
		const {name, website, description} = this.props.link;

		return (
			<li>
				<a
					href={website} target={'_blank'}>{name}</a> - {description}
			</li>
		);
	}

}