import React, { Component } from "react";
import { Board } from "./Board";
import axios from "axios";

import retry from "retry";

const operation = retry.operation({
  retries: 5,
  factor: 3,
  minTimeout: 1 * 1000,
  maxTimeout: 60 * 1000,
  randomize: true
});

export class Survey extends Component {
  static displayName = Survey.name;

  constructor(props) {
    super(props);
    this.state = {
      texts: [],
      groups: [],
      email: sessionStorage.getItem("email"),
      surveyId: null,
      variantId: null
    };

    this.handleTextResponse.bind(this);
    this.getSurveyForUser.bind(this);
    this.populateGroups(this);
    this.populateTexts(this);
  }

  async getSurveyForUser(email) {
    await axios({
      method: "POST",
      url: `/api/user/${email}/survey`,
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        "Access-Control-Allow-Origin": "*"
      },
      data: null
    }).then(response => {
      this.setState({
        surveyId: response.data.surveyId,
        variantId: response.data.variantId
      });
      sessionStorage.setItem("surveyId", response.data.surveyId);
      sessionStorage.setItem("variantId", response.data.variantId);
    });
  }

  populateGroups() {
    this.setState({
      groups: [
        { groupId: 0 },
        { groupId: 1 },
        { groupId: 2 },
        { groupId: 3 },
        { groupId: 4 },
        { groupId: 5 }
      ]
    });
  }

  handleTextResponse(response) {
    var texts = response.data;
    texts.forEach(text => (text.group = 0));
    texts.forEach(text => (text.id = text.textId));
    this.setState({ texts: texts });
  }

  populateTexts() {
    if (this.state.variantId === undefined) {
      this.getSurveyForUser(this.state.email);
    }
    axios({
      method: "GET",
      url: `/api/text?variantId=${this.state.variantId}`
    }).then(response => this.handleTextResponse(response));
  }

  componentDidMount() {
    this.getSurveyForUser(this.state.email);
    this.populateGroups();
    this.populateTexts();
  }

  render() {
    if (this.state.variantId === null) {
      this.getSurveyForUser(this.state.email);
    }

    if (this.state.texts.length === 0) {
      this.populateTexts();
    }

    const getByGroup = (group, items) =>
      items.filter(text => text.group === group.groupId);

    const groupTextMap = this.state.groups.reduce(
      (previous, group) => ({
        ...previous,
        [group.groupId]: getByGroup(group, this.state.texts)
      }),
      {}
    );
    console.log(JSON.stringify(groupTextMap[0]));
    return (
      <React.Fragment>
        <h1>Survey</h1>
        <Board
          initial={groupTextMap}
          texts={this.state.texts}
          groups={this.state.groups}
          {...this.state}
        />
      </React.Fragment>
    );
  }
}
