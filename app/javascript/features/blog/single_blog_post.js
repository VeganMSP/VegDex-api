import React, { Component } from 'react';
import PropTypes from "prop-types";
import { format } from "date-fns";
import withRouter from '../../helpers/withRouter';

class SingleBlogPost extends Component {
	constructor(props){
		super(props);
		this.state = {
			slug: this.props.params.slug,
			blog_post: {},
			loading: true
		}
	}

	static propTypes = {
		post: PropTypes.object.isRequired,
	}

	componentDidMount() {
		this.getBlogPost(this.state.slug)
	}

	static renderBlogPost(blog_post){
		const { title, content, created_at, status } = blog_post
		console.log(blog_post);
		return (
			<div className='post-stub'>
				<h3 className='post-title'>
					<span className='date xs-hidden'>
						{format(new Date(created_at), 'yyyy-MM-dd')}
						&nbsp;
						{title}
					</span>
				</h3>
				<p className='post-content'>{blog_post.content}</p>
			</div>
		)
	}

	render() {
		let content = this.state.loading
			? <p><em>Loading...</em></p>
			: SingleBlogPost.renderBlogPost(this.state.blog_post);
		return (
			<>
				{content}
			</>
		);
	}

	async getBlogPost(slug) {
		const reponse = await fetch('/api/v1/blog_posts?' + new URLSearchParams({
			slug: slug
		}));
		const data = await reponse.json();
		this.setState({blog_post: data, loading: false});
	}
}

export default withRouter(SingleBlogPost);