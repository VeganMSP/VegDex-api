import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import {format} from 'date-fns';
import PropTypes from "prop-types";
import NewBlogPost from './_new_blog_post';
import {BASE_API_URL} from '../config';
import {IBlogPost} from '../models/IBlogPost';

interface IState {
  blog_posts: IBlogPost[];
  loading: boolean
}

export class Blog extends Component<any, IState> {
  constructor(props: any) {
    super(props);
    this.state = {
      blog_posts: [],
      loading: true
    };
    this.handleFormSubmit = this.handleFormSubmit.bind(NewBlogPost);
  }

  handleFormSubmit(title: string, content: string, status: string) {
    console.log(title, content, status);
  }

  componentDidMount() {
    this.getBlogPosts();
  }

  static renderBlogPosts(blog_posts: IBlogPost[]) {
    if (blog_posts.length > 0) {
      return (
        <div>
          <NewBlogPost/>
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
          <NewBlogPost/>
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
    const response = await fetch(`${BASE_API_URL}/blog_posts`);
    const data = await response.json();
    this.setState({blog_posts: data, loading: false});
  }
}

class BlogPost extends Component<{ post: IBlogPost }> {
  constructor(props: { post: IBlogPost }) {
    super(props);
  }

  static propTypes = {
    post: PropTypes.object.isRequired,
  }

  render() {
    const {title, slug, content, created_at} = this.props.post;
    const date = new Date(created_at);
    const fullDate = format(date, 'yyyy-MM-dd')
    const year = format(date, 'yyyy');
    const month = format(date, 'MM');
    const day = format(date, 'dd');

    return (
      <div className='post-stub'>
        <h3 className='post-title'>
					<span className='date xs-hidden'>
						{fullDate}
            &nbsp;
					</span>
          <Link to={`/blog/${year}/${month}/${day}/${slug}`}>
            {title}
          </Link>
        </h3>
        <p className='post-content'>{content}</p>
      </div>
    );
  }
}