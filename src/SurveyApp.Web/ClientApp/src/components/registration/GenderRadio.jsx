import React, { Component } from "react";
import { FormGroup, Input, Col, Label } from "reactstrap";

export class GenderRadio extends Component {
  static displayName = GenderRadio.name;

  handleOnChange = event => {
    this.setState({
      value: event.currentTarget.id,
      gender: event.target.id
    });
    console.log("child setting english lvel");
    this.props.onChange(event.target.id);
  };

  render() {
    return (
      <FormGroup>
        <FormGroup id="gender" check>
          <Label check>
            <Input
              type="radio"
              name="gender"
              id="male"
              onChange={this.handleOnChange}
            />{" "}
            Male
          </Label>
        </FormGroup>
        <FormGroup check>
          <Label check>
            <Input
              type="radio"
              name="gender"
              id="female"
              onChange={this.handleOnChange}
            />{" "}
            Female
          </Label>
        </FormGroup>
        <FormGroup check>
          <Label check>
            <Input
              type="radio"
              name="gender"
              id="notSpecified"
              onChange={this.handleOnChange}
            />{" "}
            Prefer not to say
          </Label>
        </FormGroup>
      </FormGroup>
    );
  }
}
