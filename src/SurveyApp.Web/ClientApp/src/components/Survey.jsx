import React, { Component } from "react";
import axios from "axios";
import { Redirect } from "react-router";
import { TextEntry } from "./TextEntry";
import { Category } from "./Category";
import { Row } from "reactstrap";
import Example from "./test/example.js";
import { DndProvider } from "react-dnd";
import { HTML5Backend } from "react-dnd-html5-backend";

export class Survey extends Component {
  static displayName = Survey.name;

  constructor(props) {
    super(props);
    this.state = {
      texts: [],
      categories: [],
      loading: true,
      email: this.props.email,
      dragging: false
    };
  }

  //componentDidMount() {
  //  this.populateTexts();
  //  this.populateCategories();
  //  this.setState({ loading: false });

  //  this.dragCounter = 0;
  //}

  //async populateTexts() {
  //  const response = [
  //    {
  //      id: 0,
  //      text:
  //        "text 0 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    },
  //    {
  //      id: 1,
  //      text:
  //        "text 1 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    },
  //    {
  //      id: 2,
  //      text:
  //        "text 2 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    },
  //    {
  //      id: 3,
  //      text:
  //        "text 3 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    },
  //    {
  //      id: 4,
  //      text:
  //        "text 4 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    },
  //    {
  //      id: 5,
  //      text:
  //        "text 5 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    },
  //    {
  //      id: 6,
  //      text:
  //        "text 6 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    },
  //    {
  //      id: 7,
  //      text:
  //        "text 7 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
  //    }
  //  ];
  //  this.setState({ texts: response });
  //}

  //async populateCategories() {
  //  const response = [{ id: 1 }, { id: 2 }, { id: 3 }, { id: 4 }, { id: 5 }];
  //  //const data = await response.json();
  //  this.setState({ categories: response });
  //}

  //onDrag = (event, text) => {
  //  event.preventDefault();
  //  console.log("drag: " + text.id);

  //  this.setState({ draggedText: text });
  //};

  //onDragOver = event => {
  //  event.preventDefault();
  //};

  //onDrop = event => {
  //  const { categories, draggedText, texts } = this.state;
  //  console.log("drop: " + draggedText.id);
  //  this.setState({
  //    categories: [...categories, draggedText],
  //    texts: texts.filter(text => text.id !== draggedText.id),
  //    draggedText: {}
  //  });
  //};

  render() {
    return (
      <React.Fragment>
        <h1>Survey</h1>

        <DndProvider backend={HTML5Backend}>
          <Example />
        </DndProvider>
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
//    <br />
//    <br />
//    <br />
//    <Row className="categories">
//        {this.state.categories.map(category => (
//            <Category
//                className="droppable"
//                droppable
//                key={category.id}
//                categoryId={category.id}
//                onDrop={event => this.onDrop(event)}
//                onDragOver={event => this.onDragOver(event)}
//            />
//        ))}
//    </Row>
