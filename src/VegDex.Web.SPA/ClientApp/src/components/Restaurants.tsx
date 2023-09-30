import React, {Component} from "react";
import {City} from "./City";
import {ICity} from "../models/ICity";

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

  static renderRestaurantsList(restaurants_by_city: ICity[]) {
    return (
      <div>
        {restaurants_by_city.length > 0 ? <>
          {restaurants_by_city.map(city =>
            <City
              key={city.slug}
              city={city}
              restaurants={city.restaurants}
            />)}
        </> : <>
          <p>There are no restaurants in the database.</p>
        </>}
      </div>
    );
  }

  static renderCityList(restaurants_by_city: ICity[]) {
    return (
      <div>
        {restaurants_by_city.length > 0 ? <>
          Jump to city:
          <ul>
            {restaurants_by_city.map(city =>
              <li key={city.slug}><a href={"#" + city.slug}>{city.name}</a></li>
            )}
          </ul>
        </> : <>
          <p>No cities in the database.</p>
        </>}
      </div>
    );
  }

  componentDidMount() {
    this.populateRestaurantsByCity();
  }

  render() {
    const contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Restaurants.renderRestaurantsList(this.state.restaurants_by_city);
    const city_list = this.state.loading
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
    const response = await fetch("/api/v1/Restaurants");
    const data = await response.json();
    this.setState({restaurants_by_city: data, loading: false});
  }
}