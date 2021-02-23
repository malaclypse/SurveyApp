import React, { Component } from "react";
import { Container, NavItem, NavLink } from "reactstrap";
import { Link } from "react-router-dom";

export class Footer extends Component {
  static displayName = Footer.name;

  render() {
    return (
      <div>
        <Container>
          <hr />

          <NavLink tag={Link} to="https://nbu.bg/en">
            <div>© New Bulgarian University 2021</div>
          </NavLink>
          <NavLink tag={Link} to="https://computerscience.nbu.bg/en">
            <div>© NBU, Department of Computer Science 2021</div>
          </NavLink>
          <NavLink tag={Link} to="/admin">
            Admin
          </NavLink>
        </Container>
      </div>
    );
  }
}
