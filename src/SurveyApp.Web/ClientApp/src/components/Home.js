import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Button, NavLink, Row, Col, Container, NavItem } from "reactstrap";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Home</h1>
        <br />

        <Container className="themed-container" fluid="sm">
          <Row>
            <h5>
              If you have registered already, please
              <Link tag={Link} to="/login">
                {" "}
                log in.
              </Link>{" "}
            </h5>
          </Row>
          <br />
          <Row>
            <h5>
              If you are a new user, please
              <Link tag={Link} to="/register">
                {" "}
                register.
              </Link>{" "}
            </h5>
          </Row>
        </Container>
      </div>
    );
  }
}
