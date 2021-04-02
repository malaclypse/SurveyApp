import React, { Component } from "react";
import {
  Button,
  Table,
  Input,
  Alert,
  Row,
  Col,
  InputGroupAddon,
  InputGroup,
  TabContent,
  TabPane,
  Nav,
  NavItem,
  NavLink,
  Form
} from "reactstrap";
import axios from "axios";
import { Redirect } from "react-router";
import classnames from "classnames";
import { languages } from "../registration/languages.js";
import { countries } from "../registration/countries.js";

export class AdminPage extends Component {
  static displayName = AdminPage.name;
  constructor(props) {
    super(props);
    this.state = {
      mappings: [],
      surveys: [],
      users: [],
      isAuthenticated: false,
      password: null,
      token: null,
      validate: {
        password: ""
      },
      visible: false,
      activeTab: "1",
      languages: languages,
      countries: countries
    };

    if (localStorage.getItem("token") !== null) {
      this.state.token = localStorage.getItem("token");
      this.state.isAuthenticated = true;
    }

    this.getMappings.bind(this);
    this.renderMappingTable.bind(this);
    this.getMatrix.bind(this);
    this.addPassword = this.addPassword.bind(this);
    this.login.bind(this);
    this.validatePasswordField.bind(this);
    this.onDismiss.bind(this);
  }

  async login() {
    console.log(this.state.password);
    if (localStorage.getItem("token") != null) {
      const { validate } = this.state;
      validate.password = "";
      this.setState({
        isAuthenticated: true,
        visible: false,
        token: localStorage.getItem("token")
      });
    }

    await axios({
      method: "POST",
      url: `/api/admin/login`,
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*"
      },
      data: JSON.stringify(this.state.password)
    })
      .then(response => {
        this.setState({
          isAuthenticated: true,
          token: response.data.tokenString
        });
        localStorage.setItem("token", this.state.token);
      })
      .catch(err => {
        if (err.response.status === 401) {
          const { validate } = this.state;
          validate.password = "has-danger";
          this.setState({
            isAuthenticated: false,
            visible: true,
            validate
          });
          return;
        } else {
          console.log(err);
        }
      });
  }

  async getMatrix() {
    axios({
      url: "/api/admin/matrix", //your url
      method: "GET",
      responseType: "blob" // important
    }).then(response => {
      const url = window.URL.createObjectURL(new Blob([response.data]));
      const link = document.createElement("a");
      link.href = url;
      link.setAttribute("download", "matrix.csv"); //or any other extension
      document.body.appendChild(link);
      link.click();
    });
  }

  async getMappings() {
    await axios({
      method: "GET",
      url: `/api/admin/mappings`,
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        "Access-Control-Allow-Origin": "*",
        Authorization: `Bearer ${this.state.token}`
      },
      data: null
    }).then(response => {
      this.setState({
        mappings: response.data
      });
    });
  }

  async getSurveys() {
    await axios({
      method: "GET",
      url: `/api/admin/surveys`,
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        "Access-Control-Allow-Origin": "*",
        Authorization: `Bearer ${this.state.token}`
      },
      data: null
    }).then(response => {
      this.setState({
        surveys: response.data
      });
    });
  }

  async getUsers() {
    await axios({
      method: "GET",
      url: `/api/admin/users`,
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        "Access-Control-Allow-Origin": "*",
        Authorization: `Bearer ${this.state.token}`
      },
      data: null
    }).then(response => {
      this.setState({
        users: response.data
      });
    });
  }

  addPassword(event) {
    this.setState({ password: event.target.value }, () => {
      console.log(this.state.password);
    });
  }

  onDismiss() {
    const { validate } = this.state;
    validate.password = "";
    this.setState({ visible: false, validate }, () => {
      console.log(this.state.visible);
    });
  }

  validatePasswordField(e) {
    const { validate } = this.state;
    if (e.target.value == null || e.target.value === undefined) {
      validate.password = "has-danger";
    } else {
      validate.password = "has-success";
    }
    this.setState({ validate });
  }

  renderMappingTable() {
    return this.state.mappings.map((mapping, index) => {
      const { mappingId, textId, groupId, surveyId, isDeleted } = mapping;
      return (
        <tr key={mappingId}>
          <td>{mappingId}</td>
          <td>{textId}</td>
          <td>{groupId}</td>
          <td>{surveyId}</td>
          <td>{isDeleted && "✓"}</td>
        </tr>
      );
    });
  }

  renderSurveyTable() {
    return this.state.surveys.map((survey, index) => {
      const {
        surveyId,
        variantId,
        userEmail,
        isCompleted,
        createdDate,
        finishedOnDate
      } = survey;
      return (
        <tr key={surveyId}>
          <td>{surveyId}</td>
          <td>{variantId}</td>
          <td>{userEmail}</td>
          <td>{isCompleted && "✓"}</td>
          <td>{createdDate}</td>
          <td>{finishedOnDate}</td>
        </tr>
      );
    });
  }

  renderUserTable() {
    return this.state.users.map((user, index) => {
      const {
        email,
        englishLevel,
        nativeLanguage,
        gender,
        education,
        country,
        isInterestedInMoreInfo
      } = user;

      var language = this.state.languages.find(obj => {
        return obj.code === nativeLanguage;
      }).name;
      var countryName = this.state.countries.find(obj => {
        return obj.code === country;
      });
      return (
        <tr key={email}>
          <td>{email}</td>
          <td>{englishLevel}</td>
          <td>{language}</td>
          <td>{gender}</td>
          <td>{education}</td>
          <td>{countryName == null ? null : countryName.name}</td>
          <td>{isInterestedInMoreInfo && "✓"}</td>
        </tr>
      );
    });
  }

  toggle(tab) {
    if (this.state.activeTab !== tab) {
      this.setState(
        {
          activeTab: tab
        },
        () => {
          console.log(this.state.activeTab);
        }
      );
    }
  }

  renderAdminContent() {
    if (this.state.isAuthenticated === true) {
      if (this.state.mappings.length === 0) {
        this.getMappings();
      }
      if (this.state.surveys.length === 0) {
        this.getSurveys();
      }
      if (this.state.users.length === 0) {
        this.getUsers();
      }
    }

    const activeTab = this.state.activeTab;
    return (
      <React.Fragment>
        <Row>
          <Button outline color="primary" onClick={this.getMatrix}>
            Download Matrix csv
          </Button>
        </Row>{" "}
        <hr />
        <Nav tabs>
          <NavItem>
            <NavLink
              className={classnames({ active: activeTab === "1" })}
              onClick={() => {
                this.toggle("1");
              }}
            >
              GroupTextMapping
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink
              className={classnames({ active: activeTab === "2" })}
              onClick={() => {
                this.toggle("2");
              }}
            >
              Surveys
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink
              className={classnames({ active: activeTab === "3" })}
              onClick={() => {
                this.toggle("3");
              }}
            >
              Users
            </NavLink>
          </NavItem>
        </Nav>
        <TabContent activeTab={activeTab}>
          <TabPane tabId="1">
            <h2>GroupTextMapping Table</h2>
            <Table striped bordered size="sm">
              <thead>
                <tr>
                  <th>MappingId</th>
                  <th>TextId</th>
                  <th>GroupId</th>
                  <th>SurveyId</th>
                  <th>IsDeleted</th>
                </tr>
              </thead>
              <tbody>{this.renderMappingTable()}</tbody>
            </Table>
          </TabPane>
          <TabPane tabId="2">
            <h2>Surveys Table</h2>
            <Table striped bordered size="sm">
              <thead>
                <tr>
                  <th>SurveyId</th>
                  <th>VariantId</th>
                  <th>UserEmail</th>
                  <th>IsCompleted</th>
                  <th>CreatedDate</th>
                  <th>FinishedOnDate</th>
                </tr>
              </thead>
              <tbody>{this.renderSurveyTable()}</tbody>
            </Table>
          </TabPane>
          <TabPane tabId="3">
            <h2>Users Table</h2>
            <Table striped bordered size="sm">
              <thead>
                <tr>
                  <th>Email</th>
                  <th>EnglishLevel</th>
                  <th>NativeLanguage</th>
                  <th>Gender</th>
                  <th>Education</th>
                  <th>Country</th>
                  <th>isInterestedInMoreInfo</th>
                </tr>
              </thead>
              <tbody>{this.renderUserTable()}</tbody>
            </Table>
          </TabPane>
        </TabContent>
      </React.Fragment>
    );
  }

  renderAdminLogin() {
    return (
      <React.Fragment>
        <h5>This page is meant only for the administrators of the survey.</h5>
        <Row xs="3">
          <Col>
            <InputGroup>
              <Alert
                color="danger"
                isOpen={this.state.visible}
                toggle={this.onDismiss.bind(this)}
              >
                Wrong password! Please try again!
              </Alert>

              <Input
                type="password"
                name="password"
                id="password"
                placeholder="Password"
                valid={this.state.validate.password === "has-success"}
                invalid={this.state.validate.password === "has-danger"}
                onChange={e => {
                  this.validatePasswordField(e);
                  this.addPassword(e);
                }}
              />
              <InputGroupAddon addonType="append">
                <Button
                  color="primary"
                  type="button"
                  onClick={this.login.bind(this)}
                >
                  Login
                </Button>
              </InputGroupAddon>
            </InputGroup>
          </Col>
        </Row>
      </React.Fragment>
    );
  }

  render() {
    return (
      <React.Fragment>
        <h1>Admin</h1>{" "}
        {this.state.isAuthenticated
          ? this.renderAdminContent()
          : this.renderAdminLogin()}
      </React.Fragment>
    );
  }
}
