import React from "react";
import styled from "@emotion/styled";
import { colors } from "@atlaskit/theme";
import { borderRadius, grid } from "../constants";
import { TextEntry } from "../TextEntry";
import { ModalBody, Modal } from "reactstrap";

const getBackgroundColor = (isDragging, isGroupedOver, authorColors) => {
  if (isDragging) {
    return authorColors.soft;
  }

  if (isGroupedOver) {
    return colors.N30;
  }

  return colors.N0;
};

const getBorderColor = (isDragging, authorColors) =>
  isDragging ? authorColors.hard : "transparent";

const Container = styled.a`
  border-radius: ${borderRadius}px;
  border: 2px solid transparent;
  border-color: ${props => getBorderColor(props.isDragging, props.colors)};
  background-color: ${props =>
    getBackgroundColor(props.isDragging, props.isGroupedOver, props.colors)};
  box-shadow: ${({ isDragging }) =>
    isDragging ? `2px 2px 1px ${colors.N70}` : "none"};
  padding: ${grid}px;
  min-height: 40px;
  margin-bottom: ${grid}px;
  user-select: none;

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
  &::before {
    content: open-quote;
  }
  &::after {
    content: close-quote;
  }
`;

// Previously this extended React.Component
// That was a good thing, because using React.PureComponent can hide
// issues with the selectors. However, moving it over does can considerable
// performance improvements when reordering big lists (400ms => 200ms)
// Need to be super sure we are not relying on PureComponent here for
// things we should be doing in the selector as we do not know if consumers
// will be using PureComponent
export default class QuoteItem extends React.PureComponent {
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

    const extraContent = this.props.text.text;

    const content =
      extraContent.length > 40
        ? extraContent.substring(0, 37) + "..."
        : extraContent;

    return (
      <Container
        isDragging={isDragging}
        isGroupedOver={isGroupedOver}
        colors={colors.backgroundOnLayer}
        ref={provided.innerRef}
        {...provided.draggableProps}
        {...provided.dragHandleProps}
      >
        <BlockQuote text={text.text} textId={text.id} onClick={this.toggle}>
          {content}
        </BlockQuote>
        <Modal isOpen={this.state.modal} toggle={this.toggle}>
          <ModalBody>{extraContent}</ModalBody>
        </Modal>
      </Container>
    );
  }
}

//          <BlockQuote>{quote.content}</BlockQuote>
//<Footer>
//    <Author colors={quote.author.colors}>{quote.author.name}</Author>
//    <QuoteId>id:{quote.id}</QuoteId>
//</Footer>

//constructor(props) {
//    super(props);
//    this.state = {
//        displayedText: null,
//        showFullText: false,
//        modal: false
//    };
//}

//toggle = () => {
//    this.setState({ modal: !this.state.modal });
//};

//render() {
//    const extraContent = this.props.text;

//    const content =
//        extraContent.length > 40
//            ? extraContent.substring(0, 37) + "..."
//            : extraContent;
//    return (
//        <React.Fragment>
//            <Col>
//                <Toast id={this.props.textId} onClick={this.toggle}>
//                    <ToastBody>{content}</ToastBody>
//                </Toast>
//                <Modal isOpen={this.state.modal} toggle={this.toggle}>
//                    <ModalBody>{extraContent}</ModalBody>
//                </Modal>
//            </Col>
//        </React.Fragment>
//    );
//}
//}
