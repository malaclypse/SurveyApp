import React, { Component } from "react";
import { Board } from "./Board";
//import { texts, groups } from "./data";

export class Survey extends Component {
  static displayName = Survey.name;

  constructor(props) {
    super(props);
    this.state = {
      email: this.props.email,
      texts: [],
      groups: []
    };
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

  populateTexts() {
    this.setState({
      texts: [
        {
          id: 1,
          text:
            "text 1 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        },
        {
          id: 2,
          text:
            "text 2 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        },
        {
          id: 3,
          text:
            "text 3 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        },
        {
          id: 4,
          text:
            "text 4 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        },
        {
          id: 5,
          text:
            "text 5 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        },
        {
          id: 6,
          text:
            "text 6 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        },
        {
          id: 7,
          text:
            "text 7 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        },
        {
          id: 8,
          text:
            "text 8 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
          group: 0
        }
      ]
    });
  }

  componentDidMount() {
    this.populateGroups();
    this.populateTexts();
  }

  render() {
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
        />
      </React.Fragment>
    );
  }
}
