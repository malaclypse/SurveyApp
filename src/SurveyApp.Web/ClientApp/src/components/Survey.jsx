import React, { Component } from "react";
import { Board } from "./Board";
import { groupTextMap, texts, groups } from "./data";

export class Survey extends Component {
  static displayName = Survey.name;

  constructor(props) {
    super(props);
    this.state = {
      email: this.props.email
    };
  }

  render() {
    return (
      <React.Fragment>
        <h1>Survey</h1>
        <Board initial={groupTextMap} texts={texts} groups={groups} />
      </React.Fragment>
    );
  }
}
