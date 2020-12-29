import React, { Component } from "react";
import {
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  FormGroup,
  Label
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
        <Label for="englishLevel">
          Select your highest completed education level (optional)
        </Label>

        <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggle} outline>
          <DropdownToggle caret>{this.state.dropDownText}</DropdownToggle>
          <DropdownMenu>
            <DropdownItem header>
              Education level (highest completed)
            </DropdownItem>
            <DropdownItem
              id="NoProficiency"
              onClick={event => this.setState({})}
            >
              0 - No Proficiency
            </DropdownItem>
            <DropdownItem
              id="ElementaryProficiency"
              onClick={this.handleOnChange}
            >
              1 - Elementary Proficiency
            </DropdownItem>
            <DropdownItem
              id="LimitedWorkingProficiency"
              onClick={this.handleOnChange}
            >
              2 - Limited Working Proficiency
            </DropdownItem>
            <DropdownItem
              id="ProfessionalProficiency"
              onClick={this.handleOnChange}
            >
              3 - Professional Proficiency
            </DropdownItem>
            <DropdownItem
              id="FullProfessionalProficiency"
              onClick={this.handleOnChange}
            >
              4 - Full Professional Proficiency
            </DropdownItem>
            <DropdownItem
              id="NativeOrBilingualProficiency"
              onClick={this.handleOnChange}
            >
              5 - Native / Bilingual Proficiency
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>
      </FormGroup>
    );
  }
}
