import React, { Component } from 'react';
import { Button, Form, Col, FormGroup, Input, Modal, ModalBody, Label } from 'reactstrap';
import NewLinkCategory from "./_new_link_category";

class NewLink extends Component {
    constructor(props) {
        super(props);
        this.state = {
            link_categories: [],
            newLinkModal: false,
            form: {}
        };
        this.toggleLinkForm = this.toggleLinkForm.bind(NewLink);
    }

    toggleLinkForm = () => {
        console.log(this);
        this.setState(prevState => ({
            newLinkModal: !prevState.newLinkModal
        }));
    }

    handleChange = (e) => {
        this.state.form[e.target.name] = e.target.value;
    }

    submitForm = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch('/api/v1/links', {
                method: 'POST',
                body: JSON.stringify(this.state.form),
                headers: {
                    Accept: 'application/json',
                    'Content-Type': 'application/json',
                },
            });
            if (!response.ok) throw Error(response.statusText);
            e.target.reset();
            this.toggleLinkForm();
        } catch (error) {
            console.error(error);
        }
    }

    componentDidMount() {
        this.populateLinkCategories();
    }

    static renderLinkCategoryOptions(link_categories){
        return (
            <>
                {link_categories.map(category =>
                    <option value={category.id}>{category.name}</option>
                )}
            </>
        )
    }

    render() {
        let categories = this.state.loading
            ? <p><em>Loading...</em></p>
            : NewLink.renderLinkCategoryOptions(this.state.link_categories);

        return (
            <>
                <Button id="link_form_toggle" type="primary" onClick={this.toggleLinkForm}>
                    Create New + ({this.state.newLinkModal.toString()})
                </Button>

                <Modal
                    isOpen={this.state.newLinkModal}
                    toggle={this.toggleLinkForm}
                >
                    <ModalBody>
                        <Form onSubmit={(e) => {
                            e.preventDefault();
                            this.submitForm(e);
                        }
                        }>
                            <FormGroup row>
                                <Label for="name"
                                       sm={2}>
                                    Name:
                                </Label>
                                <Col sm={10}>
                                    <Input id="name"
                                           name="name"
                                           onChange={this.handleChange}
                                    />
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label for="description"
                                       sm={2}>
                                    Description:
                                </Label>
                                <Col sm={10}>
                                    <Input id="description"
                                           name="description"
                                           type="textarea"
                                           onChange={this.handleChange}
                                    />
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label for="website"
                                       sm={2}>
                                    Website:
                                </Label>
                                <Col sm={10}>
                                    <Input id="website"
                                           name="website"
                                           onChange={this.handleChange}
                                    />
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label for="link_category_id"
                                       sm={2}>
                                    Category:
                                </Label>
                                <Col sm={10}>
                                    <Input id="link_category_id"
                                           name="link_category_id"
                                           type="select"
                                           onChange={this.handleChange}
                                    >
                                        {categories}
                                    </Input>
                                    <NewLinkCategory/>
                                </Col>
                            </FormGroup>
                            <Button color="primary">Submit</Button>
                        </Form>
                    </ModalBody>
                </Modal>
            </>
        )
    }

    async populateLinkCategories() {
        const response = await fetch('api/v1/link_categories');
        const data = await response.json();
        this.setState({link_categories: data, loading: false});
    }

}

export default NewLink
