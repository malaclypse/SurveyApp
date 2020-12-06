import React, { Component } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";

export class LoginForm extends Component {
  render() {
    return (
      <React.Fragment>
        <h1>Log In</h1>
        <Form>
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
        </Form>
      </React.Fragment>
    );
  }
}
