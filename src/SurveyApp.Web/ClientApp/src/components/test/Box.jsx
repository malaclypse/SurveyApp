import React, { useState } from "react";
import { useDrag } from "react-dnd";
import { Toast, ToastBody, Col, Modal, ModalBody } from "reactstrap";

const style = {
  border: "1px dashed gray",
  backgroundColor: "white",
  padding: "0.5rem 1rem",
  marginRight: "0.1rem",
  marginBottom: "1.5rem",
  fontSize: "0.9rem",
  cursor: "move",
  float: "left",
  boxShadow: "0 4px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 10px 0 rgba(0, 0, 0, 0.19)"
};

export const Box = ({ name, type, isDropped, text }) => {
  const [modal, toggle] = useState(false);

  const [{ opacity }, drag] = useDrag({
    item: { name, type },
    collect: monitor => ({
      opacity: monitor.isDragging() ? 0.4 : 1
    })
  });

  const showText = () => {
    toggle(!modal);
  };

  const previewText =
    text.text.length > 40 ? text.text.substring(0, 37) + "..." : text.text;

  return (
    <Col>
      <div
        ref={drag}
        style={{ ...style, opacity }}
        id={text.textId}
        onClick={showText}
      >
        {isDropped ? <s>{previewText}</s> : previewText}

        <Modal isOpen={modal} toggle={showText}>
          <ModalBody>{text.text}</ModalBody>
        </Modal>
      </div>
    </Col>
  );
};
//<Toast >
//    <ToastBody>{content}</ToastBody>
//</Toast>
