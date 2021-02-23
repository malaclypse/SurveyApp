import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { LoginForm } from "./components/LoginForm";
import { RegistrationForm } from "./components/registration/RegistrationForm";
import { Survey } from "./components/survey/Survey";
import { SurveyCompletedPage } from "./components/SurveyCompletedPage";
import { AdminPage } from "./components/admin/AdminPage";
import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/login" component={LoginForm} />
        <Route path="/register" component={RegistrationForm} />
        <Route path="/survey" component={Survey} />
        <Route path="/surveycompleted" component={SurveyCompletedPage} />
        <Route path="/admin" component={AdminPage} />
      </Layout>
    );
  }
}
