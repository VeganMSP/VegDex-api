import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Layout } from './components/Layout';
import './custom.scss';

import { Home } from './components/Home';
import { Restaurants } from "./components/Restaurants";
import { Shopping } from "./components/Shopping";
import { Links } from "./components/Links";
import { Blog } from "./components/Blog";
import { About } from "./components/About";
import SingleBlogPost from "./features/blog/single_blog_post";

export default class App extends Component {
	static displayName = App.name;

	render() {
		return (
			<Layout>
				<Routes>
					<Route path='/' exact element={<Home/>}/>
					<Route path='/restaurants' exact element={<Restaurants/>}/>
					<Route path='/shopping' exact element={<Shopping/>}/>
					<Route path='/links' exact element={<Links/>}/>
					<Route path='/blog' exact element={<Blog/>}/>
					<Route path='/blog/:year/:month/:day/:slug' element={<SingleBlogPost/>}/>
					<Route path='/about' exact element={<About/>}/>
				</Routes>
			</Layout>
		);
	}
}
