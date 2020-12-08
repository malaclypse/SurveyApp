import React, { Component } from "react";
import { Toast, ToastBody, Col, Modal, ModalBody } from "reactstrap";
import { useDrag, useDrop } from "react-dnd";

export class TextEntry extends Component {
  static displayName = TextEntry.name;

  constructor(props) {
    super(props);
    this.state = {
      displayedText: null,
      showFullText: false,
      modal: false
    };
  }

  toggle = () => {
    this.setState({ modal: !this.state.modal });
  };

  render() {
    const extraContent = this.props.text.text;

    const content =
      extraContent.length > 40
        ? extraContent.substring(0, 37) + "..."
        : extraContent;
    return (
      <React.Fragment>
        <Col>
          <Toast id={this.props.text.textId} onClick={this.toggle}>
            <ToastBody>{content}</ToastBody>
          </Toast>
          <Modal isOpen={this.state.modal} toggle={this.toggle}>
            <ModalBody>{extraContent}</ModalBody>
          </Modal>
        </Col>
      </React.Fragment>
    );
  }
}
