"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var reactstrap_1 = require("reactstrap");
var Login = /** @class */ (function (_super) {
    __extends(Login, _super);
    function Login() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    //type LoginProps =
    //    LoginStore.LoginState &
    //    typeof LoginStore.actionCreators &
    //    RouteComponentProps<{}>;
    //class Login extends React.PureComponent<LoginProps> {
    Login.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement("h1", null, "Counter"),
            React.createElement("p", null, "This is a simple example of a React component."),
            React.createElement(reactstrap_1.Button, null, "Log In")));
    };
    return Login;
}(React.Component));
;
//export default connect(
//    (state: ApplicationState) => state.counter,
//    LoginStore.actionCreators
//)(Counter);
//# sourceMappingURL=Login.js.map