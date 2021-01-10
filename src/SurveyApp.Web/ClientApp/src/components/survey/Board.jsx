import React, { Component } from "react";
import styled from "@emotion/styled";
import { Global, css } from "@emotion/react";
import { colors } from "@atlaskit/theme";
import { DragDropContext, Droppable } from "react-beautiful-dnd";
import { Form, Button, Row, Col, UncontrolledAlert } from "reactstrap";
import axios from "axios";
import { Redirect } from "react-router";
import Column from "./column";
import reorder, { reorderQuoteMap } from "./reorder";

const ParentContainer = styled.div`
  /* height: ${({ height }) => height}; */
  overflow-x: hidden;
  overflow-y: auto; 
background-color: ${colors.N10};
`;

const Container = styled.div`
  background-color: ${colors.N10};
  min-height: 100vh;
  /* like display:flex but will allow bleeding over the window width */
  min-width: 100vw;
  display: inline-flex;
`;

const InitialArea = styled.div`
  background-color: transparent;

  width: fit-content;
  /* To adjust the height as well */
  height: fit-content;
`;

export class Board extends Component {
  /* eslint-disable react/sort-comp */
  static defaultProps = {
    isCombineEnabled: false
  };

  state = {
    columns: this.props.initial,
    ordered: Object.keys(this.props.initial),
    texts: this.props.texts,
    groups: this.props.groups,
    redirect: false,
    alertVisible: false
  };

  boardRef;

  componentDidUpdate(prevProps) {
    if (prevProps.initial !== this.props.initial) {
      this.setState({
        columns: this.props.initial,
        ordered: Object.keys(this.props.initial),
        texts: this.props.texts,
        groups: this.props.groups
      });
    }
  }

  onDragEnd = result => {
    if (result.combine) {
      if (result.type === "COLUMN") {
        const shallow = [...this.state.ordered];
        shallow.splice(result.source.index, 1);
        this.setState({ ordered: shallow });
        return;
      }

      const column = this.state.columns[result.source.droppableId];
      const withQuoteRemoved = [...column];
      withQuoteRemoved.splice(result.source.index, 1);
      const columns = {
        ...this.state.columns,
        [result.source.droppableId]: withQuoteRemoved
      };
      this.setState({ columns });
      return;
    }

    // dropped nowhere
    if (!result.destination) {
      return;
    }

    const source = result.source;
    const destination = result.destination;

    // did not move anywhere - can bail early
    if (
      source.droppableId === destination.droppableId &&
      source.index === destination.index
    ) {
      return;
    }

    // reordering column
    if (result.type === "COLUMN") {
      const ordered = reorder(
        this.state.ordered,
        source.index,
        destination.index
      );

      this.setState({
        ordered
      });

      return;
    }

    const data = reorderQuoteMap({
      quoteMap: this.state.columns,
      source,
      destination
    });

    this.setState({
      columns: data.quoteMap
    });
    console.log("source: " + source.droppableId);
    console.log("destination: " + destination.droppableId);
    console.log("item: " + result.draggableId);
    console.log("columns: " + JSON.stringify(this.state.columns[0]));

    if (destination.droppableId === 0 || destination.droppableId === "0") {
      axios({
        method: "GET",
        url: `/api/user/${this.props.email}/survey/${
          this.props.surveyId
        }/map?textId=${parseInt(result.draggableId)}`
      }).then(response => {
        this.setState({ mappingId: response.data.mappingId });
      });

      if (this.state.mappingId !== undefined) {
        axios({
          method: "DELETE",
          url: `/api/user/${this.props.email}/survey/${
            this.props.surveyId
          }/map/${this.state.mappingId}`
        }).then(response => {});
      }
    } else {
      axios({
        method: "POST",
        url: `/api/user/${this.props.email}/survey/${this.props.surveyId}/map`,
        data: {
          surveyId: this.props.surveyId,
          textId: parseInt(result.draggableId),
          groupId: parseInt(destination.droppableId)
        }
      }).then(response => {
        console.log(JSON.stringify(response));
      });
    }
  };

  submitForm(e) {
    e.preventDefault();
    var request = {
      surveyId: this.state.surveyId
    };
    console.log(request);

    //axios({
    //    method: "PUT",
    //    url: "/api/survey",
    //    data: request
    //}).then(response => this.handleRedirect(response));

    if (this.state.columns["0"].length === 0) {
      this.setState({ redirect: true });
    } else {
      this.setState({ alertVisible: true });
    }
  }

  handleRedirect(response) {
    this.setState({ redirect: true });
    console.log(response.data);
    console.log(response.status);
    console.log(response.statusText);
    console.log(response.headers);
    console.log(response.config);
  }

  render() {
    const { redirect } = this.state;
    if (redirect) {
      return <Redirect to="/surveycompleted" />;
    }

    const columns = this.state.columns;
    const ordered = this.state.ordered;
    const { containerHeight } = this.props;

    const board = (
      <Droppable
        droppableId="board"
        type="COLUMN"
        direction="horizontal"
        ignoreContainerClipping={Boolean(containerHeight)}
        isCombineEnabled={this.props.isCombineEnabled}
      >
        {(provided, snapshot) => (
          <React.Fragment>
            <InitialArea ref={provided.innerRef} {...provided.droppableProps}>
              <Column
                key={"0"}
                index={0}
                title={"0"}
                texts={columns["0"]}
                isScrollable={this.props.withScrollableColumns}
                isCombineEnabled={this.props.isCombineEnabled}
                isInitialArea
              />
            </InitialArea>
            <Container ref={provided.innerRef} {...provided.droppableProps}>
              {ordered.map(
                (key, index) =>
                  (key != 0 || key !== "0") && (
                    <Column
                      key={key}
                      index={index}
                      title={key}
                      texts={columns[key]}
                      isScrollable={this.props.withScrollableColumns}
                      isCombineEnabled={this.props.isCombineEnabled}
                    />
                  )
              )}
              {provided.placeholder}
            </Container>
          </React.Fragment>
        )}
      </Droppable>
    );
    console.log("columns: " + JSON.stringify(this.state.columns[0]));

    return (
      <React.Fragment>
        {this.state.alertVisible && (
          <UncontrolledAlert color="danger">
            Please group all texts before submitting!
          </UncontrolledAlert>
        )}
        <Form className="survey" onSubmit={e => this.submitForm(e)}>
          <Row>
            <Col>
              <p>
                Click on each text to expand it and read it, then group the
                texts into the five groups below.
              </p>
              <p>
                Your progress is automatically saved on each drop, so you can
                return later to finish.
              </p>
            </Col>
            <Col lg="auto">
              <Button
                outline
                color="secondary"
                onClick={event => window.location.reload()}
              >
                Reset
              </Button>
            </Col>
            <Col lg="auto">
              <Button color="primary">Submit attempt</Button>
            </Col>
          </Row>
          <Row>
            <DragDropContext onDragEnd={this.onDragEnd}>
              {containerHeight ? (
                <ParentContainer height={containerHeight}>
                  {board}
                </ParentContainer>
              ) : (
                board
              )}
            </DragDropContext>
          </Row>
        </Form>
        <Global
          styles={css`
            body {
              background: ${colors.N10};
            }
          `}
        />
      </React.Fragment>
    );
  }
}
