import React, {Component} from 'react';
import {Button, Form, Col, FormGroup, Input, Modal, ModalBody, Label} from 'reactstrap';
import AsyncCreatableSelect from "react-select/async-creatable";

export const BlogPostStatus = {
  DRAFT: 0,
  PUBLISHED: 1
};

class NewBlogPost extends Component {
  constructor(props) {
    super(props);
    this.state = {
      modal: false,
      form: {}
    };

    this.toggle = this.toggle.bind(this);
  }

  toggle = () => {
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  }

  handleChange = (e) => {
    this.state.form[e.target.name] = e.target.value;
  }

  handleBlogPostCategorySelectChange = (e) => {
    // TODO: handle new category creation here
    this.state.form['blog_post_category_id'] = e.id;
  }

  submitForm = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('/api/v1/blog_posts', {
        method: 'POST',
        body: JSON.stringify(this.state.form),
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
      });
      if (!response.ok) throw Error(response.statusText);
      e.target.reset();
      this.toggle();
    } catch (error) {
      console.error(error);
    }
  }

  render() {

    return (
      <>
        <Button type="primary" onClick={this.toggle}>
          Create New +
        </Button>

        <Modal
          isOpen={this.state.modal}
          toggle={this.toggle}
        >
          <ModalBody>
            <Form onSubmit={(e) => {
              e.preventDefault();
              this.submitForm(e);
            }
            }>
              <FormGroup row>
                <Label for="title"
                       sm={2}>
                  Title:
                </Label>
                <Col sm={10}>
                  <Input id="title"
                         name="title"
                         onChange={this.handleChange}
                  />
                </Col>
              </FormGroup>
              <FormGroup row>
                <Label for="content"
                       sm={2}>
                  Content:
                </Label>
                <Col sm={10}>
                  <Input id="content"
                         name="content"
                         type="textarea"
                         onChange={this.handleChange}
                  />
                </Col>
              </FormGroup>
              <FormGroup row>
                <Label for="blog_post_category_id"
                       sm={2}>
                  Category:
                </Label>
                <Col sm={10}>
                  <AsyncCreatableSelect id="blog_post_category_id"
                                        name="blog_post_category_id"
                                        cacheOptions
                                        defaultOptions
                                        isClearable
                                        getOptionLabel={e => e.name}
                                        getOptionValue={e => e.id}
                                        loadOptions={this.populateBlogPostCategories}
                                        onChange={this.handleBlogPostCategorySelectChange}
                  />
                </Col>
              </FormGroup>
              <FormGroup row>
                <Label for="status"
                       sm={2}>
                  Status
                </Label>
                <Col sm={10}>
                  <Input id="status"
                         name="status"
                         type="select"
                         onChange={this.handleChange}
                  >
                    <option value={BlogPostStatus.DRAFT} selected>Draft</option>
                    <option value={BlogPostStatus.PUBLISHED}>Published</option>
                  </Input>
                </Col>
              </FormGroup>
              <Button color="primary">Submit</Button>
            </Form>
          </ModalBody>
        </Modal>
      </>
    )
  }

  async populateBlogPostCategories() {
    const response = await fetch('api/v1/blog_post_categories');
    const data = await response.json();
    return data;
  }
}

export default NewBlogPost