import React, { PropTypes } from "react";
import { Route } from "react-router-dom";
import { Redirect } from "react-router";

function RestrictedRoute({ component: Component, authed, ...rest }) {
  return (
    <Route
      {...rest}
      render={props =>
        authed === true ? (
          <Component {...props} />
        ) : (
          <Redirect
            to={{ pathname: "/login", state: { from: props.location } }}
          />
        )
      }
    />
  );
}
