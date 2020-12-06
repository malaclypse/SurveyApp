import React, { Component } from "react";
import {
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Col
} from "reactstrap";
import axios from "axios";
import { Redirect } from "react-router";

export class RegistrationForm extends Component {
  static displayName = RegistrationForm.name;

  constructor(props) {
    super(props);

    this.submitForm.bind(this);
    this.state = {
      email: null,
      sex: null,
      nativeLanguage: null,
      englishLevel: null,
      dropdownOpen: false,
      value: "Home",
      redirect: false
    };

    this.toggle = this.toggle.bind(this);
    this.select = this.select.bind(this);
  }

  toggle() {
    this.setState({
      dropdownOpen: !this.state.dropdownOpen
    });
  }

  select(event) {
    this.setState({
      dropdownOpen: !this.state.dropdownOpen,
      value: event.target.innerText
    });
  }

  submitForm(e) {
    e.preventDefault();
    var request = {
      email: this.state.email,
      sex: this.state.sex,
      nativeLanguage: this.state.nativeLanguage,
      englishLevel: this.state.englishLevel
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
        <h1>Register</h1>
        <Form className="registration" onSubmit={e => this.submitForm(e)}>
          <Col md={4}>
            <FormGroup>
              <Label for="email">Email</Label>
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
            <Label for="sex">Sex</Label>
            <FormGroup id="sex" check>
              <Label check>
                <Input
                  type="radio"
                  name="sex"
                  id="male"
                  onChange={event => this.setState({ sex: event.target.id })}
                />{" "}
                Male
              </Label>
            </FormGroup>
            <FormGroup check>
              <Label check>
                <Input
                  type="radio"
                  name="sex"
                  id="female"
                  onChange={event => this.setState({ sex: event.target.id })}
                />{" "}
                Female
              </Label>
            </FormGroup>
            <FormGroup check>
              <Label check>
                <Input
                  type="radio"
                  name="sex"
                  id="notSaying"
                  onChange={event => this.setState({ sex: event.target.id })}
                />{" "}
                Prefer not to say
              </Label>
            </FormGroup>
          </Col>

          <br />
          <Col md={4}>
            <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggle}>
              <DropdownToggle caret>
                English level (self-assessed)
              </DropdownToggle>
              <DropdownMenu>
                <DropdownItem header>
                  English level (self-assessed)
                </DropdownItem>
                <DropdownItem
                  id="level0"
                  onClick={event =>
                    this.setState({
                      englishLevel: event.currentTarget.id
                    })
                  }
                >
                  0 - No Proficiency
                </DropdownItem>
                <DropdownItem
                  id="level1"
                  onClick={event =>
                    this.setState({
                      englishLevel: event.currentTarget.id
                    })
                  }
                >
                  1 - Elementary Proficiency
                </DropdownItem>
                <DropdownItem
                  id="level2"
                  onClick={event =>
                    this.setState({
                      englishLevel: event.currentTarget.id
                    })
                  }
                >
                  2 - Limited Working Proficiency
                </DropdownItem>
                <DropdownItem
                  id="level3"
                  onClick={event =>
                    this.setState({
                      englishLevel: event.currentTarget.id
                    })
                  }
                >
                  3 - Professional Proficiency
                </DropdownItem>
                <DropdownItem
                  id="level4"
                  onClick={event =>
                    this.setState({
                      englishLevel: event.currentTarget.id
                    })
                  }
                >
                  4 - Full Professional Proficiency
                </DropdownItem>
                <DropdownItem
                  id="level5"
                  onClick={event =>
                    this.setState({
                      englishLevel: event.currentTarget.id
                    })
                  }
                >
                  5 - Native / Bilingual Proficiency
                </DropdownItem>
              </DropdownMenu>
            </Dropdown>
          </Col>

          <br />
          <Col md={4}>
            <FormGroup>
              <Label for="nativeLanguage">Native Language</Label>
              <Input
                type="text"
                name="nativeLanguage"
                id="nativeLanguage"
                placeholder="Native Language"
                onChange={event =>
                  this.setState({ nativeLanguage: event.target.value })
                }
              />
            </FormGroup>
          </Col>
          <Col md={4}>
            <Button>Register</Button>
          </Col>
        </Form>
      </React.Fragment>
    );
  }
}
