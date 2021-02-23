import React, { Component } from "react";
import { FormGroup } from "reactstrap";
import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete";
import { countries } from "./countries.js";

export class CountryDropdown extends Component {
  static displayName = CountryDropdown.name;
  constructor(props) {
    super(props);
    this.state = {
      nativeLanguage: null,
      countries: countries
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
        <Autocomplete
          id="country"
          options={this.state.countries}
          getOptionLabel={option => option.name}
          style={{ width: 300 }}
          onChange={(event, value) => this.handleOnChange(event, value)}
          renderInput={params => <TextField {...params} label="Country" />}
        />
      </FormGroup>
    );
  }
}
