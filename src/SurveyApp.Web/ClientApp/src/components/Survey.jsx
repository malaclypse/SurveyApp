import React, { Component } from "react";
import axios from "axios";
import { Redirect } from "react-router";

import { Board } from "./Board";

import { groupTextMap, texts, groups } from "./data";

export class Survey extends Component {
  static displayName = Survey.name;

  constructor(props) {
    super(props);
    this.state = {
      loading: true,
      email: this.props.email,
      dragging: false
    };
  }

  render() {
    return (
      <React.Fragment>
        <h1>Survey</h1>
        <Board initial={groupTextMap} texts={texts} groups={groups} />
      </React.Fragment>
    );
  }
}

//<Row className="texts">
//    {this.state.texts.map(text => (
//        <TextEntry
//            className="draggable"
//            draggable
//            key={text.id}
//            class="text"
//            text={text}
//            onDrag={event => this.onDrag(event, text)}
//        />
//    ))}
//</Row>

//<Row className="texts">
//    <Droppable droppableId="initial">
//        {(provided, snapshot) => (
//            <div ref={provided.innerRef} {...provided.droppableProps}>
//                Good to go
//                {provided.placeholder}
//            </div>
//        )}
//        {this.state.texts.map((text, index) => (
//            <Draggable draggableId={text.id} index={index}>
//                {(provided, snapshot) => (
//                    <TextEntry
//                        ref={provided.innerRef}
//                        {...provided.draggableProps}
//                        {...provided.dragHandleProps}
//                        key={text.id}
//                        class="text"
//                        text={text}
//                    />
//                )}
//            </Draggable>
//        ))}
//    </Droppable>
//</Row>
//    <Row className="groups">
//        <div>
//            <Droppable>
//                {this.state.groups.map(group => (
//                    <Group key={group.id} categoryId={group.id} />
//                ))}
//            </Droppable>
//        </div>
//    </Row>
