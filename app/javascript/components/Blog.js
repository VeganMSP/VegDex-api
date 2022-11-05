import React, { Component } from 'react';
import {format} from 'date-fns';
import PropTypes from "prop-types";

export class Blog extends Component {
	constructor(props) {
		super(props);
		this.state = {
			blog_posts: [],
			loading: true
		};
	}

	componentDidMount() {
		this.getBlogPosts();
	}

	static renderBlogPosts(blog_posts) {
		if (blog_posts.length > 0) {
			return (
				<div>
					<ul>
						{blog_posts.map(post =>
							<BlogPost
								key={post.slug}
								post={post}
							/>
						)}
					</ul>
				</div>
			)
		} else {
			return (
				<div>
					<p>There are no blog posts in the database!</p>
				</div>
			)
		}
	}

	render() {
		let blog_posts = this.state.loading
			? <p><em>Loading...</em></p>
			: Blog.renderBlogPosts(this.state.blog_posts);
		return (
			<>
				<div>
					{blog_posts}
				</div>
			</>
		);
	}

	async getBlogPosts() {
		const response = await fetch('api/v1/blog_posts');
		const data = await response.json();
		this.setState({blog_posts: data, loading: false});
	}
}

class BlogPost extends Component {
	static propTypes = {
		post: PropTypes.object
	}

	render() {
		const {title, content, created_at} = this.props.post;

		return (
			<div className='post-stub'>
				<h3 className='post-title'>
					<span className='date xs-hidden'>
						{format(new Date(created_at), 'yyyy-MM-dd')}
						&nbsp;
					</span>
					<a href="/blog/post/{slug}">
						{title}
					</a>
				</h3>
				<p className='post-content'>{content}</p>
			</div>
		);
	}
}