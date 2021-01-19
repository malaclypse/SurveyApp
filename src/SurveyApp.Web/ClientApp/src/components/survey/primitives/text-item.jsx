import React from "react";
import styled from "@emotion/styled";
import { colors } from "@atlaskit/theme";
import { borderRadius, grid } from "../constants";
import { ModalBody, Modal } from "reactstrap";

const getBackgroundColor = (isDragging, isGroupedOver, authorColors) => {
  if (isDragging) {
    return colors.N0;
  }

  if (isGroupedOver) {
    return colors.N30;
  }

  return colors.N0;
};

const getBorderColor = (isDragging, authorColors) =>
  isDragging ? authorColors.hard : "lightgrey";

const Container = styled.a`
  border-radius: ${borderRadius}px;
  border: 2px solid;
  border-color: ${props => getBorderColor(props.isDragging, props.colors)};
  background-color: ${props =>
    getBackgroundColor(props.isDragging, props.isGroupedOver, props.colors)};
  box-shadow: ${({ isDragging }) =>
    isDragging ? `2px 2px 1px ${colors.N70}` : "none"};
  padding: ${grid}px;
  user-select: none;
  margin: ${grid - 2}px;
  max-width: 120px;
  float: left;
  /* anchor overrides */
  color: ${colors.N900};

  &:hover,
  &:active {
    color: ${colors.N900};
    text-decoration: none;
  }

  &:focus {
    outline: none;
    border-color: ${props => props.colors.hard};
    box-shadow: none;
  }

  /* flexbox */
  display: flex;
`;

const BlockQuote = styled.div`
  --lh: 1.2rem;
  line-height: var(--lh);

  --max-lines: 4;
  font-size: 14px;
  position: relative;
  max-height: calc(var(--lh) * var(--max-lines));
  overflow: hidden;

  &::before {
    position: absolute;
    content: "...";
    inset-block-end: 0; /* "bottom" */
    inset-inline-end: 0; /* "right" */
  }
  &::after {
    content: "";
    position: absolute;
    inset-inline-end: 0; /* "right" */
    width: 1rem;
    height: 1rem;
    background: white;
  }
`;

export default class TextItem extends React.PureComponent {
  constructor(props) {
    super(props);
    this.state = {
      modal: false
    };
  }

  toggle = () => {
    this.setState({ modal: !this.state.modal });
  };

  render() {
    const { text, isDragging, isGroupedOver, provided } = this.props;

    const content = text.text;

    return (
      <Container
        isDragging={isDragging}
        isGroupedOver={isGroupedOver}
        colors={colors.backgroundOnLayer}
        ref={provided.innerRef}
        {...provided.draggableProps}
        {...provided.dragHandleProps}
      >
        <BlockQuote
          text={text.text}
          textId={text.id}
          onClick={this.toggle}
          className="truncate"
        >
          {content}
        </BlockQuote>
        <Modal isOpen={this.state.modal} toggle={this.toggle} size="lg">
          <ModalBody>{content.split("\n").map(str => <p>{str}</p>)}</ModalBody>
        </Modal>
      </Container>
    );
  }
}
