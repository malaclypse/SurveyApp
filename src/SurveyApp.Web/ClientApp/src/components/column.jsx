import React, { Component } from "react";
import styled from "@emotion/styled";
import { colors } from "@atlaskit/theme";
import { grid } from "./constants";
import { Droppable } from "react-beautiful-dnd";
import TextList from "./primitives/text-list";

const Container = styled.div`
  margin: ${grid}px;
  display: flex;
  flex-direction: column;
`;

export default class Column extends Component {
  render() {
    const title = this.props.title;
    const texts = this.props.texts;
    const index = this.props.index;
    return (
      <Droppable droppableId={title} index={index}>
        {(provided, snapshot) => (
          <Container ref={provided.innerRef} {...provided.draggableProps}>
            <TextList
              listId={title}
              listType="QUOTE"
              style={{
                backgroundColor: snapshot.isDragging ? colors.G50 : null
              }}
              texts={texts}
              internalScroll={this.props.isScrollable}
              isCombineEnabled={Boolean(this.props.isCombineEnabled)}
              isInitialArea={this.props.isInitialArea}
            />
          </Container>
        )}
      </Droppable>
    );
  }
}
