import React, { useState } from "react";
import { useDrag } from "react-dnd";
import { Toast, ToastBody, Col, Modal, ModalBody } from "reactstrap";

const style = {
  border: "1px dashed gray",
  backgroundColor: "white",
  padding: "0.5rem 1rem",
  marginRight: "1.5rem",
  marginBottom: "1.5rem",
  cursor: "move",
  float: "left",
  boxShadow: "0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)"
};

export const Box = ({ name, type, isDropped }) => {
  const [modal, toggle] = useState(false);
  const [text] = useState({ text: "test", textId: 1 });
  const [{ opacity }, drag] = useDrag({
    item: { name, type },
    collect: monitor => ({
      opacity: monitor.isDragging() ? 0.4 : 1
    })
  });

  const showText = () => {
    toggle(!modal);
  };

  const extraContent = text.text;

  const content =
    extraContent.length > 40
      ? extraContent.substring(0, 37) + "..."
      : extraContent;

  return (
    <Col>
      <div
        ref={drag}
        style={{ ...style, opacity }}
        id={text.textId}
        onClick={showText}
      >
        {isDropped ? <s>content</s> : content}

        <Modal isOpen={modal} toggle={showText}>
          <ModalBody>{extraContent}</ModalBody>
        </Modal>
      </div>
    </Col>
  );
};
//<Toast >
//    <ToastBody>{content}</ToastBody>
//</Toast>
