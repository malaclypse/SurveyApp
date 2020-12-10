import { useDrop } from "react-dnd";
import React, { useState, useCallback } from "react";
import { ListGroup, ListGroupItem, Col } from "reactstrap";

const style = {
  height: "6rem",
  width: "12rem",
  marginRight: "1.5rem",
  marginBottom: "1.5rem",
  color: "black",
  padding: "1rem",
  textAlign: "center",
  fontSize: "0.8rem",
  lineHeight: "normal",
  float: "left",
  border: "1px solid lightgrey",
  borderRadius: "5px",
  boxShadow: "5px 8px 15px grey"
};

export const Dustbin = ({ accept, lastDroppedItem, onDrop, items }) => {
  const [{ isOver, canDrop }, drop] = useDrop({
    accept,
    drop: onDrop,
    collect: monitor => ({
      isOver: monitor.isOver(),
      canDrop: monitor.canDrop()
    })
  });

  const isActive = isOver && canDrop;
  let backgroundColor = "#fff";
  if (isActive) {
    backgroundColor = "lightgreen";
  } else if (canDrop) {
    backgroundColor = "grey";
  }

  return (
    <div ref={drop} style={{ ...style, backgroundColor }}>
      {isActive ? "Release to drop" : ` `}
      {items
        ? items.map((item, index) => {
            console.log(item.textId);
            JSON.stringify(item);
          })
        : " "}
      {lastDroppedItem && (
        <p>Last dropped: {JSON.stringify(lastDroppedItem)}</p>
      )}
    </div>
  );
};
