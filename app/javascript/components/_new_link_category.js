import React, { Component } from 'react';
import { Button, Form, Col, FormGroup, Input, Modal, ModalBody, Label } from 'reactstrap';

class NewLinkCategory extends Component {
    constructor(props) {
        super(props);
        this.state = {
            newLinkCategoryModal: false,
            form: {}
        };
        this.toggleLinkCategoryForm = this.toggleLinkCategoryForm.bind(NewLinkCategory)
        this.submitLinkCategoryForm = this.submitLinkCategoryForm.bind(NewLinkCategory)
    }

    toggleLinkCategoryForm = () => {
        console.log(this);
        this.setState(prevState => ({
            newLinkCategoryModal: !prevState.newLinkCategoryModal
        }));
    }

    handleChange = (e) => {
        this.state.form[e.target.name] = e.target.value;
    }

    submitLinkCategoryForm = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch('/api/v1/link_categories', {
                method: 'POST',
                body: JSON.stringify(this.state.form),
                headers: {
                    Accept: 'application/json',
                    'Content-Type': 'application/json',
                },
            });
            if (!response.ok) throw Error(response.statusText);
            e.target.reset();
            this.toggleLinkCategoryForm();
        } catch (error) {
            console.error(error);
        }
    }

    render() {

        return (
            <>
                <Button id="link_category_form_toggle" onClick={this.toggleLinkCategoryForm}>
                    Create New + ({this.state.newLinkCategoryModal.toString()})
                </Button>

                <Modal
                    isOpen={this.state.newLinkCategoryModal}
                    toggle={this.toggleLinkCategoryForm}
                >
                    <ModalBody>
                        <Form onSubmit={(e) => {
                            e.preventDefault();
                            this.submitLinkCategoryForm(e);
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
                            <Button color="primary">Submit</Button>
                        </Form>
                    </ModalBody>
                </Modal>
            </>
        )
    }
}

export default NewLinkCategory
