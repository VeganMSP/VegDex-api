import React, {Component} from "react";
import PropTypes from "prop-types";
import NewLink from "./_new_link";
import {ILinkCategory} from "../models/ILinkCategory";
import {ILink} from "../models/ILink";

interface IState {
  links_by_category: ILinkCategory[];
  loading: boolean;
}

export class Links extends Component<any, IState> {
  static displayName = Links.name;

  constructor(props: any) {
    super(props);
    this.state = {
      links_by_category: [],
      loading: true
    };
  }

  static renderLinksList(links_by_category: ILinkCategory[]) {
    return (
      <div>
        {links_by_category.length > 0 ? <>
          {links_by_category.map(category =>
            <LinkCategory
              key={category.slug}
              category={category}
              links={category.links}
            />)}
        </> : <>
          <p>There are no links in the database.</p>
        </>}
      </div>
    );
  }

  componentDidMount() {
    this.populateLinksByCategory();
  }

  render() {
    const contents = this.state.loading
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
    const response = await fetch("/api/v1/Links");
    const data = await response.json();

    this.setState({links_by_category: data, loading: false});
  }
}

export class LinkCategory extends Component<{ category: ILinkCategory, links: ILink[] }> {
  static propTypes = {
    category: PropTypes.object,
    links: PropTypes.array
  };

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
    );
  }
}

export class Link extends Component<{ link: ILink }> {
  static propTypes = {
    link: PropTypes.object,
  };

  render() {
    const {name, website, description} = this.props.link;

    return (
      <li>
        <a
          href={website} target={"_blank"} rel="noreferrer">{name}</a> - {description}
      </li>
    );
  }

}