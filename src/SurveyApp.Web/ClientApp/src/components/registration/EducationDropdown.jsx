import React, { Component } from "react";
import {
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  FormGroup
} from "reactstrap";

export class EducationDropdown extends Component {
  static displayName = EducationDropdown.name;

  constructor(props) {
    super(props);
    this.state = {
      dropdownOpen: false,
      dropDownValue: null,
      dropDownText: "Education level (highest completed)"
    };

    this.toggle = this.toggle.bind(this);
    this.select = this.select.bind(this);
  }

  toggle() {
    this.setState({
      dropdownOpen: !this.state.dropdownOpen
    });
  }

  select(event) {
    this.setState({
      dropdownOpen: !this.state.dropdownOpen,
      value: event.target.innerText
    });
  }

  handleOnChange = event => {
    this.setState({
      value: event.currentTarget.id,
      dropDownValue: event.currentTarget.id,
      englishLevel: event.currentTarget.id,
      dropDownText: event.currentTarget.textContent
    });
    this.props.onChange(event.currentTarget.id);
  };

  render() {
    return (
      <FormGroup>
        <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggle}>
          <DropdownToggle caret>{this.state.dropDownText}</DropdownToggle>
          <DropdownMenu>
            <DropdownItem header>
              Education level (highest completed)
            </DropdownItem>
            <DropdownItem id="HighSchool" onClick={event => this.setState({})}>
              High School
            </DropdownItem>
            <DropdownItem id="BachelorsDegree" onClick={this.handleOnChange}>
              Bachelors Degree
            </DropdownItem>
            <DropdownItem id="MastersDegree" onClick={this.handleOnChange}>
              MastersDegree
            </DropdownItem>
            <DropdownItem id="DoctorateOrHigher" onClick={this.handleOnChange}>
              DoctorateOrHigher
            </DropdownItem>
            <DropdownItem id="Other" onClick={this.handleOnChange}>
              Other
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>
      </FormGroup>
    );
  }
}
