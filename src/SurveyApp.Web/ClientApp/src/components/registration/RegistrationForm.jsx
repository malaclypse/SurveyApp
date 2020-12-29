import React, { Component } from "react";
import { Button, Form, FormGroup, Label, Input, Col } from "reactstrap";
import axios from "axios";
import { Redirect } from "react-router";
import { LanguageDropdown } from "./LanguageDropdown";
import { EnglishDropdown } from "./EnglishDropdown";
import { GenderRadio } from "./GenderRadio";
import { EducationDropdown } from "./EducationDropdown";

export class RegistrationForm extends Component {
  static displayName = RegistrationForm.name;

  constructor(props) {
    super(props);

    this.submitForm.bind(this);
    this.state = {
      email: null,
      gender: null,
      nativeLanguage: null,
      englishLevel: null,
      education: null,
      value: "Home",
      redirect: false
    };
  }

  submitForm(e) {
    e.preventDefault();
    var request = {
      email: this.state.email,
      gender: this.state.gender,
      nativeLanguage: this.state.nativeLanguage,
      englishLevel: this.state.englishLevel,
      education: this.state.education
    };
    console.log(request);

    axios({
      method: "POST",
      url: "/api/user",
      data: request
    }).then(response => this.handleRedirect(response));
  }

  addEnglishLevel(value) {
    this.setState({ englishLevel: value });
  }

  addNativeLanguage(value) {
    this.setState({ nativeLanguage: value });
  }

  addGender(value) {
    this.setState({ gender: value });
  }

  addEducationLevel(value) {
    this.setState({ education: value });
  }

  handleRedirect(response) {
    this.setState({ redirect: true });
    console.log(response.data);
    console.log(response.status);
    console.log(response.statusText);
    console.log(response.headers);
    console.log(response.config);
  }

  render() {
    const { redirect } = this.state;
    if (redirect) {
      return <Redirect to="/survey" />;
    }
    return (
      <React.Fragment>
        <h1>Register</h1>
        <Form className="registration" onSubmit={e => this.submitForm(e)}>
          <Col md={4}>
            <FormGroup>
              <Label for="email">Email*</Label>
              <Input
                type="email"
                name="email"
                id="email"
                placeholder="Email"
                onChange={event => this.setState({ email: event.target.value })}
              />
            </FormGroup>
          </Col>
          <Col md={4}>
            <GenderRadio
              name="gender"
              id="gender"
              onChange={this.addGender.bind(this)}
            />
          </Col>
          <Col md={4}>
            <EnglishDropdown
              name="englishLevel"
              id="englishLevel"
              placeholder="English level(self-assessed)"
              onChange={this.addEnglishLevel.bind(this)}
            />
          </Col>
          <Col md={4}>
            <EducationDropdown
              name="education"
              id="education"
              placeholder="English level(self-assessed)"
              onChange={this.addEducationLevel.bind(this)}
            />
          </Col>
          <Col md={4}>
            <LanguageDropdown
              name="nativeLanguage"
              id="nativeLanguage"
              placeholder="Native Language"
              onChange={this.addNativeLanguage.bind(this)}
            />
          </Col>
          <Col md={4}>
            <Button color="primary">Register</Button>
          </Col>
        </Form>
      </React.Fragment>
    );
  }
}
