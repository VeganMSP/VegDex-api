import React, {ChangeEvent, Component, FormEvent} from "react";
import {Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody} from "reactstrap";
import AsyncCreatableSelect from "react-select/async-creatable";
import {ILinkCategory} from "../models/ILinkCategory";

interface IState {
  link_categories: string[],
  newLinkModal: boolean,
  form: { [key: string]: string }
}

class NewLink extends Component<any, IState> {
  constructor(props: any) {
    super(props);
    this.state = {
      link_categories: [],
      newLinkModal: false,
      form: {}
    };
    this.toggleLinkForm = this.toggleLinkForm.bind(NewLink);
  }

  static renderLinkCategoryOptions(link_categories: ILinkCategory[]) {
    return (
      <>
        {link_categories.map(category =>
          <option key={category.id} value={category.id}>{category.name}</option>
        )}
      </>
    );
  }

  toggleLinkForm = () => {
    this.setState(prevState => ({
      newLinkModal: !prevState.newLinkModal
    }));
  };

  handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    this.setState(state => {
      state.form[e.target.name] = e.target.value;
    });
  };

  handleLinkCategorySelectChange = (e: any) => {
    console.log(typeof (e));
    // TODO: handle creating new categories here
    this.setState(state => {
      state.form["link_category_id"] = e.id;
    });
  };

  submitForm = async (e: FormEvent) => {
    e.preventDefault();
    const target = e.target as HTMLFormElement;
    try {
      const response = await fetch("/api/v1/links", {
        method: "POST",
        body: JSON.stringify(this.state.form),
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
      if (!response.ok) throw Error(response.statusText);
      target.reset();
      this.toggleLinkForm();
    } catch (error) {
      console.error(error);
    }
  };

  componentDidMount() {
    this.populateLinkCategories();
  }

  render() {

    return (
      <>
        <Button id="link_form_toggle" className={"primary"} onClick={this.toggleLinkForm}>
          Create New +
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
                  <AsyncCreatableSelect id="link_category_id"
                                        name="link_category_id"
                                        cacheOptions
                                        defaultOptions
                                        isClearable
                                        getOptionLabel={e => e.name}
                                        getOptionValue={e => e.id}
                                        loadOptions={this.populateLinkCategories}
                                        onChange={this.handleLinkCategorySelectChange}
                  />
                </Col>
              </FormGroup>
              <Button color="primary">Submit</Button>
            </Form>
          </ModalBody>
        </Modal>
      </>
    );
  }

  async populateLinkCategories() {
    const response = await fetch("api/v1/link-categories");
    const data = await response.json();
    return data;
  }

}

export default NewLink;
