import React, { Component } from "react";
import {
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  Col,
  Row,
  Alert
} from "reactstrap";
import axios from "axios";
import { Redirect } from "react-router";

export class SurveyCompletedPage extends Component {
  static displayName = SurveyCompletedPage.name;

  constructor(props) {
    super(props);
    this.state = {
      redirect: false
    };
  }

  submitForm(e) {
    e.preventDefault();
    var request = {
      surveyId: this.state.surveyId
    };
    console.log(request);

    //axios({
    //    method: "POST",
    //    url: "/api/survey",
    //    data: request
    //}).then(response => this.handleRedirect(response));
    this.setState({ redirect: true });
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
        <Row>
          <Col>
            <Alert color="secondary">
              <h4 className="alert-heading">Survey completed!</h4>
              <p>
                If you would like to complete another version of this survey,
                please click below:
              </p>
              <hr />
              <Form className="final" onSubmit={e => this.submitForm(e)}>
                <Button outline color="primary">
                  Start new survey
                </Button>
              </Form>
            </Alert>
          </Col>
        </Row>
      </React.Fragment>
    );
  }
}
