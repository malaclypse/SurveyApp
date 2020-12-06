import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { ApplicationState } from '../../store';

class Login extends React.Component {
//type LoginProps =
//    LoginStore.LoginState &
//    typeof LoginStore.actionCreators &
//    RouteComponentProps<{}>;

//class Login extends React.PureComponent<LoginProps> {
    public render() {
        return (
            <React.Fragment>
                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <

                <Button>
                    Log In
                </Button>
            </React.Fragment>
        );
    }
};

//export default connect(
//    (state: ApplicationState) => state.counter,
//    LoginStore.actionCreators
//)(Counter);