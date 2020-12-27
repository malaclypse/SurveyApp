import React, { Component } from "react";
import styled from "@emotion/styled";
import { colors } from "@atlaskit/theme";
import { grid, borderRadius } from "./constants";
import { Droppable } from "react-beautiful-dnd";
import QuoteList from "./primitives/quote-list";
import Title from "./primitives/title";

const Container = styled.div`
  margin: ${grid}px;
  display: flex;
  flex-direction: column;
`;

const Header = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  border-top-left-radius: ${borderRadius}px;
  border-top-right-radius: ${borderRadius}px;
  background-color: ${({ isDragging }) =>
    isDragging ? colors.G50 : colors.N30};
  transition: background-color 0.2s ease;
  &:hover {
    background-color: ${colors.G50};
  }
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
            <QuoteList
              listId={title}
              listType="QUOTE"
              style={{
                backgroundColor: snapshot.isDragging ? colors.G50 : null
              }}
              texts={texts}
              internalScroll={this.props.isScrollable}
              isCombineEnabled={Boolean(this.props.isCombineEnabled)}
            />
          </Container>
        )}
      </Droppable>
    );
  }
}
//<Header isDragging={snapshot.isDragging}>
//    <Title
//        isDragging={snapshot.isDragging}
//        {...provided.dragHandleProps}
//    >
//        {title}
//    </Title>
//</Header>
