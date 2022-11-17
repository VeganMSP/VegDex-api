import React, { Component } from 'react';
import { Button, Form, Col, FormGroup, Input, Modal, ModalBody, Label } from 'reactstrap';

export const BlogPostStatus = {
	DRAFT: 0,
	PUBLISHED: 1
};

class NewBlogPost extends Component {
	constructor(props) {
		super(props);
		this.state = {
			modal: false,
			form: {
				status: BlogPostStatus.DRAFT,
				blog_post_category_id: 1
			}
		};

		this.toggle = this.toggle.bind(this);
	}

	toggle = () => {
		this.setState(prevState => ({
			modal: !prevState.modal
		}));
		console.log(this.state.modal);
	}

	handleChange = (e) => {
		this.state.form[e.target.name] = e.target.value;
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
					Create New + ({this.state.modal.toString()})
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
}

export default NewBlogPost