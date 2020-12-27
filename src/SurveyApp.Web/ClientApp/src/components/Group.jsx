import React, { Component } from "react";
import { ListGroup, ListGroupItem, Col } from "reactstrap";
export class Group extends Component {
  render() {
    return (
      <React.Fragment>
        <Col>
          <ListGroup id={this.props.categoryId}>
            <ListGroupItem>{this.props.categoryId}</ListGroupItem>
          </ListGroup>
        </Col>
      </React.Fragment>
    );
  }
}
