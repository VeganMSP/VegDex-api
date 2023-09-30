import React, {Component} from "react";
import PropTypes from "prop-types";
import {IFarmersMarket} from "../models/IFarmersMarket";
import {IVeganCompany} from "../models/IVeganCompany";

interface IState {
	farmers_markets: IFarmersMarket[];
	vegan_companies: IVeganCompany[];
	loading_vc: boolean;
	loading_fm: boolean;
}

export class Shopping extends Component<any, IState> {
	static displayName = Shopping.name;

	constructor(props: any) {
		super(props);
		this.state = {
			farmers_markets: [],
			vegan_companies: [],
			loading_vc: true,
			loading_fm: true
		};
	}

	componentDidMount() {
		this.getShoppingData();
	}

	static renderVeganCompaniesList(vegan_companies: IVeganCompany[]) {
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
			);
		} else {
			return (
				<div>
					<p>There are no vegan companies in the database!</p>
				</div>
			);
		}
	}

	static renderFarmersMarketsList(farmers_markets: IFarmersMarket[]) {
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
			);
		} else {
			return (
				<div>
					<p>There are no farmers markets in the database!</p>
				</div>
			);
		}
	}

	render() {
		const vegan_companies = this.state.loading_vc
			? <p><em>Loading...</em></p>
			: Shopping.renderVeganCompaniesList(this.state.vegan_companies);
		const farmers_markets = this.state.loading_fm
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

	async getShoppingData() {
		const response = await fetch("/api/v1/Shopping");
		const data = await response.json();
		this.setState({
			farmers_markets: data.farmersMarkets,
			vegan_companies: data.veganCompanies,
			loading_fm: false,
			loading_vc: false
		});
	}
}

class FarmersMarket extends Component<{ market: IFarmersMarket }> {
	static propTypes = {
		market: PropTypes.object
	};

	render() {
		const {name, website, address, description} = this.props.market;

		return (
			<li>
				<a href={website}>{name}</a> - {address.name} - {description}
			</li>
		);
	}
}

class VeganCompany extends Component<{ company: IVeganCompany }> {
	static propTypes = {
		company: PropTypes.object
	};

	render() {
		const {name, website, description} = this.props.company;

		return (
			<li>
				<a href={website}>{name}</a> - {description}
			</li>
		);
	}
}