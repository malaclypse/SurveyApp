import React, { Component } from "react";
import styled from "styled-components";
import { Toast, ToastBody, ToastHeader } from "reactstrap";

const TextDiv = styled.div`
  color: black;
  overflow: hidden;
  display: inline-block;
  width: 100px;
  height: 100px;
  border: 3px solid white;
  box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
`;

export class TextEntry extends Component {
  static displayName = TextEntry.name;

  render() {
    return (
      <React.Fragment>
        <Toast id={this.props.text.textId}>
          <ToastBody>{this.props.text.text}</ToastBody>
        </Toast>
      </React.Fragment>
    );
  }
}
