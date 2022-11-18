import React, { Component } from 'react';
import PropTypes from "prop-types";
import { format } from "date-fns";
import { Link } from "react-router-dom";

export default class SingleBlogPost extends Component {
	constructor(props){
		super(props);
	}

	static propTypes = {
		post: PropTypes.object.isRequired,
	}

	render() {
		console.log('here?');
		const {title, slug, content, created_at} = this.props.post;

		return (
			<>
			<div className='post-stub'>
				<h3 className='post-title'>
					<span className='date xs-hidden'>
						{format(new Date(created_at), 'yyyy-MM-dd')}
						&nbsp;
					</span>
				</h3>
				<p className='post-content'>{content}</p>
			</div>
				</>
		);
	}
}