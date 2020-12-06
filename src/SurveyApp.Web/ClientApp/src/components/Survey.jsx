import React, { Component } from "react";
import axios from "axios";
import { Redirect } from "react-router";
import { TextEntry } from "./TextEntry";
import { Category } from "./Category";
import { Row } from "reactstrap";

export class Survey extends Component {
  static displayName = Survey.name;

  constructor(props) {
    super(props);
    this.state = {
      texts: [],
      categories: [],
      loading: true,
      email: this.props.email
    };
  }

  componentDidMount() {
    this.populateTexts();
    this.populateCategories();
    this.setState({ loading: false });
  }

  render() {
    return (
      <React.Fragment>
        <h1>Survey</h1>
        <div className="texts">
          {this.state.texts.map(text => (
            <TextEntry key={text.id} class="text" text={text} />
          ))}
        </div>
        <div className="categories">
          {this.state.categories.map(category => (
            <Category key={category.id} categoryId={category.id} />
          ))}
        </div>
      </React.Fragment>
    );
  }

  async populateTexts() {
    const response = [
      { id: 0, text: "text 0" },
      { id: 1, text: "text 1" },
      { id: 2, text: "text 2" },
      { id: 3, text: "text 3" },
      { id: 4, text: "text 4" },
      { id: 5, text: "text 5" },
      { id: 6, text: "text 6" },
      { id: 7, text: "text 7" }
    ];
    //const data = await response.json();
    this.setState({ texts: response });
  }

  async populateCategories() {
    const response = [{ id: 0 }, { id: 1 }, { id: 2 }, { id: 3 }, { id: 4 }];
    //const data = await response.json();
    this.setState({ categories: response });
  }
}
