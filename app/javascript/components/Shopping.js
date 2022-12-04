import React, {Component} from 'react';
import PropTypes from "prop-types";

export class Shopping extends Component {
	static displayName = Shopping.name;

	constructor(props) {
		super(props);
		this.state = {
			farmers_markets: [],
			vegan_companies: [],
			loading_vc: true,
			loading_fm: true
		};
	}

	componentDidMount() {
		this.getVeganCompanies();
		this.getFarmersMarkets();
	}

	static renderVeganCompaniesList(vegan_companies) {
		if (vegan_companies.length > 0) {
			return (
				<div>
					<ul>
						{vegan_companies.map(company =>
							<VeganCompany
								key={company.slug}
								company={company}/>
						)}
					</ul>
				</div>
			)
		} else {
			return (
				<div>
					<p>There are no vegan companies in the database!</p>
				</div>
			)
		}
	}

	static renderFarmersMarketsList(farmers_markets) {
		if (farmers_markets.length > 0) {
			return (
				<div>
					<ul>
						{farmers_markets.map(market =>
							<FarmersMarket
								key={market.slug}
								market={market}/>
						)}
					</ul>
				</div>
			)
		} else {
			return (
				<div>
					<p>There are no farmers markets in the database!</p>
				</div>
			)
		}
	}

	render() {
		let vegan_companies = this.state.loading_vc
			? <p><em>Loading...</em></p>
			: Shopping.renderVeganCompaniesList(this.state.vegan_companies);
		let farmers_markets = this.state.loading_fm
			? <p><em>Loading...</em></p>
			: Shopping.renderFarmersMarketsList(this.state.farmers_markets);
		return (
			<>
				<div>
					<h2>Vegan Companies</h2>
					{vegan_companies}
				</div>
				<div>
					<h2>Farmers Markets</h2>
					{farmers_markets}
				</div>
			</>
		);
	}

	async getFarmersMarkets() {
		const response = await fetch('api/v1/farmers_markets');
		const data = await response.json();
		this.setState({farmers_markets: data, loading_fm: false});
	}

	async getVeganCompanies() {
		const response = await fetch('api/v1/vegan_companies');
		const data = await response.json();
		this.setState({vegan_companies: data, loading_vc: false});
	}
}

class FarmersMarket extends Component {
	static propTypes = {
		market: PropTypes.object
	}

	render() {
		const {name, website, address, description} = this.props.market;

		return (
			<li>
				<a href={website}>{name}</a> - {address.name} - {description}
			</li>
		);
	}
}