import React, { Component } from "react";
import { Button, Form, FormGroup, Label, Input, Col } from "reactstrap";
import axios from "axios";
import { Redirect } from "react-router";

export class LoginForm extends Component {
  constructor(props) {
    super(props);

    this.submitForm.bind(this);
    this.state = {
      email: null,
      value: "Home",
      redirect: false
    };
  }

  submitForm(e) {
    e.preventDefault();
    var request = {
      email: this.state.email
    };
    console.log(request);

    axios({
      method: "post",
      url: "/api/user",
      data: {
        request
      }
    }).then(() => this.setState({ redirect: true }));
  }

  render() {
    const { redirect } = this.state;
    if (redirect) {
      return <Redirect to="/survey" />;
    }
    return (
      <React.Fragment>
        <h1>Log In</h1>
        <Form onSubmit={e => this.submitForm(e)}>
          <Col md={4}>
            <FormGroup>
              <Label for="exampleEmail">Email</Label>
              <Input
                type="email"
                name="email"
                id="exampleEmail"
                placeholder="Email"
              />
            </FormGroup>
            <Button>Log In</Button>
          </Col>
        </Form>
      </React.Fragment>
    );
  }
}
