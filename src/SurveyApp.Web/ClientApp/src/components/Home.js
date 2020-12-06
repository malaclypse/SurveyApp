import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Button, NavLink } from 'reactstrap';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
         <h1>Home</h1>
        
            <h3>If you have registered already, please log in:
            <Button color="primary" size="sm" className="">
                <NavLink tag={Link} className="text-light" to="/login">Log In</NavLink>
            </Button>
          </h3>
            <h3>If you are a new user, please register: 
            <Button color="primary" size="sm">
                <NavLink tag={Link} className="text-light" to="/register">Register</NavLink>
            </Button>
            </h3>
      </div>
    );
  }
}
