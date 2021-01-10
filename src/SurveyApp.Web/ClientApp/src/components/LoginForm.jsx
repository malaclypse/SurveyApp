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

    axios({
      method: "get",
      url: `/api/user/${this.state.email}/`
    })
      .then(() => this.setState({ redirect: true }))
      .catch(error => {
        if (error.response) {
          // client received an error response (5xx, 4xx)
          if (error.response.status === 404) {
            this.setState({ redirectToRegistration: true });
          }
        } else {
          console.log(error);
        }
      });
  }

  addEmail(event) {
    sessionStorage.setItem("email", event.target.value);
    this.setState({ email: event.target.value });
  }

  render() {
    const { redirect } = this.state;
    const { redirectToRegistration } = this.state;
    if (redirect) {
      return <Redirect to="/survey" />;
    }
    if (redirectToRegistration) {
      return <Redirect to="/register" />;
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
                onChange={this.addEmail.bind(this)}
              />
            </FormGroup>
            <Button>Log In</Button>
          </Col>
        </Form>
      </React.Fragment>
    );
  }
}
