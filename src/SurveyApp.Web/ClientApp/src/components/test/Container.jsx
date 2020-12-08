import React, { useState, useCallback } from "react";
import { NativeTypes } from "react-dnd-html5-backend";
import { Dustbin } from "./Dustbin";
import { Box } from "./Box";
import { ItemTypes } from "./ItemTypes";
import update from "immutability-helper";

export const Container = () => {
  const [dustbins, setDustbins] = useState([
    { accepts: [ItemTypes.TEXT], lastDroppedItem: null, items: [] },
    { accepts: [ItemTypes.TEXT], lastDroppedItem: null, items: [] },
    { accepts: [ItemTypes.TEXT], lastDroppedItem: null, items: [] },
    { accepts: [ItemTypes.TEXT], lastDroppedItem: null, items: [] },
    { accepts: [ItemTypes.TEXT], lastDroppedItem: null, items: [] }
  ]);
  const [boxes] = useState([
    { name: "Bottle", type: ItemTypes.TEXT },
    { name: "Banana", type: ItemTypes.TEXT },
    { name: "Magazine", type: ItemTypes.TEXT }
  ]);

  const [droppedBoxNames, setDroppedBoxNames] = useState([]);
  function isDropped(boxName) {
    return droppedBoxNames.indexOf(boxName) > -1;
  }
  const handleDrop = useCallback(
    (index, item) => {
      const { name } = item;
      setDroppedBoxNames(
        update(droppedBoxNames, name ? { $push: [name] } : { $push: [] })
      );
      setDustbins(
        update(dustbins, {
          [index]: {
            lastDroppedItem: {
              $set: item
            },
            items: {
              $push: item
            }
          }
        })
      );
    },
    [droppedBoxNames, dustbins]
  );
  return (
    <div>
      <div style={{ overflow: "hidden", clear: "both" }}>
        {dustbins.map(({ accepts, lastDroppedItem, items }, index) => (
          <Dustbin
            accept={accepts}
            lastDroppedItem={lastDroppedItem}
            onDrop={item => handleDrop(index, item)}
            key={index}
            items={items}
          />
        ))}
      </div>

      <div style={{ overflow: "hidden", clear: "both" }}>
        {boxes.map(({ name, type }, index) => (
          <Box
            name={name}
            type={type}
            isDropped={isDropped(name)}
            key={index}
          />
        ))}
      </div>
    </div>
  );
};
