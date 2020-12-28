import React from "react";
import styled from "@emotion/styled";
import { colors } from "@atlaskit/theme";
import { Droppable, Draggable } from "react-beautiful-dnd";
import TextItem from "./text-item";
import { grid } from "../constants";
import Title from "./title";

const getBackgroundColor = (isDraggingOver, isDraggingFrom) => {
  if (isDraggingOver) {
    return colors.R50;
  }
  if (isDraggingFrom) {
    return colors.T50;
  }
  return colors.N30;
};

const Wrapper = styled.div`
  background-color: ${props =>
    getBackgroundColor(props.isDraggingOver, props.isDraggingFrom)};
  display: flex;
  flex-direction: column;
  opacity: ${({ isDropDisabled }) => (isDropDisabled ? 0.5 : "inherit")};
  padding: ${grid}px;
  padding-bottom: 0;
  transition: background-color 0.2s ease, opacity 0.1s ease;
  user-select: none;
  width: 200px;
  border: 2px ${colors.N10};
  border-style: inset;
  border-radius: 5px;
`;
const maxHeightInitialArea = 120;

const InitialAreaWrapper = styled.div`
  background-color: ${props =>
    getBackgroundColor(props.isDraggingOver, props.isDraggingFrom)};
  opacity: ${({ isDropDisabled }) => (isDropDisabled ? 0.5 : "inherit")};
  padding: ${grid}px;
  border: ${grid}px;
  max-height: ${maxHeightInitialArea}px;
  padding-bottom: 0;
  transition: background-color 0.1s ease, opacity 0.1s ease;
  background-color: transparent;
`;

const scrollContainerHeight = 180;
const DropZone = styled.div`
  /* stop the list collapsing when empty */
  min-height: ${scrollContainerHeight}px;
  /*
    not relying on the items for a margin-bottom
    as it will collapse when the list is empty
  */
  padding-bottom: ${grid}px;
`;

const ScrollContainer = styled.div`
  overflow-x: hidden;
  overflow-y: auto;
  max-height: ${scrollContainerHeight}px;
`;

/* stylelint-disable block-no-empty */
const Container = styled.div`
  display: flex,
  flexDirection: row,
  padding: 0,
  width: auto;
  max-height: auto;
`;
/* stylelint-enable */

class InnerTextList extends React.Component {
  shouldComponentUpdate(nextProps) {
    if (nextProps.texts !== this.props.texts) {
      return true;
    }

    return false;
  }

  render() {
    return this.props.texts.map((text, index) => (
      <Draggable
        key={text.id}
        draggableId={`${text.id}`}
        index={index}
        shouldRespectForceTouch={false}
      >
        {(dragProvided, dragSnapshot) => (
          <TextItem
            key={text.id}
            text={text}
            isDragging={dragSnapshot.isDragging}
            isGroupedOver={Boolean(dragSnapshot.combineTargetFor)}
            provided={dragProvided}
            canDragInteractiveElements
          />
        )}
      </Draggable>
    ));
  }
}

class InnerList extends React.Component {
  render() {
    const { texts, dropProvided } = this.props;
    const title = this.props.title ? <Title>{this.props.title}</Title> : null;

    return (
      <Container>
        {title}
        <DropZone ref={dropProvided.innerRef}>
          <InnerTextList texts={texts} />
          {dropProvided.placeholder}
        </DropZone>
      </Container>
    );
  }
}

export default class TextList extends React.Component {
  static defaultProps = {
    listId: "LIST"
  };
  render() {
    const {
      ignoreContainerClipping,
      internalScroll,
      scrollContainerStyle,
      isDropDisabled,
      isCombineEnabled,
      listId,
      listType,
      style,
      title,
      texts
    } = this.props;

    return (
      <Droppable
        droppableId={listId}
        type={listType}
        ignoreContainerClipping={ignoreContainerClipping}
        isDropDisabled={isDropDisabled}
        isCombineEnabled={isCombineEnabled}
      >
        {(dropProvided, dropSnapshot) =>
          this.props.isInitialArea ? (
            <InitialAreaWrapper
              style={style}
              isDraggingOver={dropSnapshot.isDraggingOver}
              isDropDisabled={isDropDisabled}
              isDraggingFrom={Boolean(dropSnapshot.draggingFromThisWith)}
              {...dropProvided.droppableProps}
            >
              {internalScroll ? (
                <ScrollContainer style={scrollContainerStyle}>
                  <InnerList
                    texts={texts}
                    title={title}
                    dropProvided={dropProvided}
                    isInitialArea={this.props.isInitialArea}
                  />
                </ScrollContainer>
              ) : (
                <InnerList
                  texts={texts}
                  title={title}
                  dropProvided={dropProvided}
                  isInitialArea={this.props.isInitialArea}
                />
              )}
            </InitialAreaWrapper>
          ) : (
            <Wrapper
              style={style}
              isDraggingOver={dropSnapshot.isDraggingOver}
              isDropDisabled={isDropDisabled}
              isDraggingFrom={Boolean(dropSnapshot.draggingFromThisWith)}
              {...dropProvided.droppableProps}
            >
              {internalScroll ? (
                <ScrollContainer style={scrollContainerStyle}>
                  <InnerList
                    texts={texts}
                    title={title}
                    dropProvided={dropProvided}
                    isInitialArea={this.props.isInitialArea}
                  />
                </ScrollContainer>
              ) : (
                <InnerList
                  texts={texts}
                  title={title}
                  dropProvided={dropProvided}
                  isInitialArea={this.props.isInitialArea}
                />
              )}
            </Wrapper>
          )
        }
      </Droppable>
    );
  }
}
