import React, { Component } from "react";
import { Link } from "react-router-dom";
import {
  Button,
  NavLink,
  Row,
  Col,
  Container,
  NavItem,
  Jumbotron
} from "reactstrap";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <Jumbotron>
          <h1>Text-Emotion Survey</h1>
          <br />

          <Container className="themed-container" fluid="sm">
            <Row>
              <p style={{ fontSize: "20px" }}>
                Text evokes emotions in its readers. <br />You will be asked to
                read eight texts in English. These are one-page excerpts from
                famous literary works.<br />
                You will be asked to group together the texts that create
                similar emotions in you.<br />
                This survey is anonymous.
                <br />
                For the purposes of language emotion analysis, you will be asked
                to specify your native language.
                <br />
                The data collected from this survey will be statistically
                analyzed to draw research conclusions in the domain of language
                and emotion.
                <br />
                Are you willing to participate in the Text Emotion Survey?
              </p>
            </Row>
            <Row>
              <h5>
                If you are a new user, please
                <Link tag={Link} to="/register">
                  {" "}
                  register.
                </Link>{" "}
              </h5>
            </Row>
            <Row>
              <h5>
                If you have registered already, please
                <Link tag={Link} to="/login">
                  {" "}
                  log in.
                </Link>{" "}
              </h5>
            </Row>
          </Container>
        </Jumbotron>
      </div>
    );
  }
}
