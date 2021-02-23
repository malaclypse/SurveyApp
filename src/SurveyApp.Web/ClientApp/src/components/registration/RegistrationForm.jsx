import React, { Component } from "react";
import {
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  Col,
  FormFeedback
} from "reactstrap";
import axios from "axios";
import { Redirect } from "react-router";
import { LanguageDropdown } from "./LanguageDropdown";
import { EnglishDropdown } from "./EnglishDropdown";
import { GenderRadio } from "./GenderRadio";
import { EducationDropdown } from "./EducationDropdown";
import { CountryDropdown } from "./CountryDropdown";

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
      country: null,
      isInterestedInMoreInfo: null,

      value: "Home",
      redirect: false,
      validate: {
        emailState: "",
        countryState: "",
        languageState: ""
      }
    };
  }

  validateEmail(e) {
    const emailRex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const { validate } = this.state;
    if (emailRex.test(e.target.value)) {
      validate.emailState = "has-success";
    } else {
      validate.emailState = "has-danger";
    }
    this.setState({ validate });
  }

  validateCountry(e) {
    const { validate } = this.state;
    if (e.target.value === "") {
      validate.countryState = "has-success";
    } else {
      validate.countryState = "has-danger";
    }
    this.setState({ validate });
  }

  submitForm(e) {
    e.preventDefault();
    if (this.state.country === undefined || this.state.country === null) {
      this.setState({ countryMissing: true });
    }
    var request = {
      email: this.state.email,
      gender: this.state.gender,
      nativeLanguage: this.state.nativeLanguage,
      englishLevel: this.state.englishLevel,
      education: this.state.education,
      country: this.state.country,
      isInterestedInMoreInfo: this.state.isInterestedInMoreInfo
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

  addCountry(value) {
    this.setState({ country: value });
  }

  addGender(value) {
    this.setState({ gender: value });
  }

  addEducationLevel(value) {
    this.setState({ education: value });
  }
  addIsInterested(event) {
    this.setState({ isInterestedInMoreInfo: event.target.checked });
    console.log(event.target.checked);
  }

  addEmail(event) {
    sessionStorage.setItem("email", event.target.value);
    this.setState({ email: event.target.value });
  }

  handleRedirect(response) {
    console.log(response.data);
    this.setState({ redirect: true });
  }

  render() {
    const { redirect } = this.state;
    if (redirect) {
      return <Redirect to="/survey" />;
    }

    return (
      <React.Fragment>
        <Form className="registration" onSubmit={e => this.submitForm(e)}>
          <h1>Register</h1>

          <FormGroup row>
            <Label for="email" sm={2}>
              Email <b>*required</b>
            </Label>
            <Col sm={4}>
              <Input
                required
                type="email"
                name="email"
                id="email"
                placeholder="Email"
                valid={this.state.validate.emailState === "has-success"}
                invalid={this.state.validate.emailState === "has-danger"}
                onChange={e => {
                  this.validateEmail(e);
                  this.addEmail(e);
                }}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="language" sm={2}>
              Native language <b>*required</b>
            </Label>
            <Col sm={4}>
              <LanguageDropdown
                name="nativeLanguage"
                id="nativeLanguage"
                placeholder="Native Language"
                valid={this.state.validate.languageState === "has-success"}
                invalid={this.state.validate.languageState === "has-danger"}
                onChange={this.addNativeLanguage.bind(this)}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="country" sm={2}>
              {" "}
              Country of origin{" "}
            </Label>
            <Col sm={4}>
              <CountryDropdown
                name="country"
                id="country"
                placeholder="Country"
                onChange={this.addCountry.bind(this)}
              />
            </Col>
          </FormGroup>

          <FormGroup row>
            <Label for="gender" sm={2}>
              Gender
            </Label>

            <Col sm={4}>
              <GenderRadio
                name="gender"
                id="gender"
                onChange={this.addGender.bind(this)}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="englishLevel" sm={2}>
              English level
            </Label>
            <Col sm={4}>
              <EnglishDropdown
                name="englishLevel"
                id="englishLevel"
                placeholder="English level(self-assessed)"
                onChange={this.addEnglishLevel.bind(this)}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="englishLevel" sm={2}>
              Highest completed education level
            </Label>
            <Col sm={4}>
              <EducationDropdown
                name="education"
                id="education"
                placeholder="English level(self-assessed)"
                onChange={this.addEducationLevel.bind(this)}
              />
            </Col>
          </FormGroup>

          <FormGroup row check>
            <Col sm={6}>
              <Label check>
                <Input
                  type="checkbox"
                  onChange={this.addIsInterested.bind(this)}
                />{" "}
                Click here if you want to be notified of the scientific analysis
                of the results of the Text Emotion Survey
              </Label>
            </Col>
          </FormGroup>
          <FormGroup row>
            <Col sm={6}>
              <Button color="primary" block>
                Register
              </Button>
            </Col>
          </FormGroup>
        </Form>
      </React.Fragment>
    );
  }
}
