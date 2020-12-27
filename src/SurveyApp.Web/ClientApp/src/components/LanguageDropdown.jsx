import React, { Component } from "react";
import { FormGroup, Label } from "reactstrap";
import { languages } from "./languages.js";
import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete";

export class LanguageDropdown extends Component {
  static displayName = LanguageDropdown.name;
  constructor(props) {
    super(props);
    this.state = {
      nativeLanguage: null,
      languages: languages
    };
  }

  handleOnChange = (event, value) => {
    if (value === null) {
      this.setState({
        nativeLanguage: ""
      });
      this.props.onChange("");
    } else {
      this.setState({
        nativeLanguage: value.code
      });
      this.props.onChange(value.code);
    }
  };

  render() {
    return (
      <FormGroup>
        <Label for="language">Select your native language (optional) </Label>
        <Autocomplete
          id="language"
          options={this.state.languages}
          getOptionLabel={option => option.name}
          style={{ width: 300 }}
          onChange={(event, value) => this.handleOnChange(event, value)}
          renderInput={params => (
            <TextField {...params} label="Native language" />
          )}
        />
      </FormGroup>
    );
  }
}
