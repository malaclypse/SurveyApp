import React, { Component } from "react";

export class Category extends Component {
  render() {
    return (
      <React.Fragment>
        <div id={this.props.categoryId}>category {this.props.categoryId}</div>
      </React.Fragment>
    );
  }
}
