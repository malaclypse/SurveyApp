import * as React from 'react';
import { connect } from 'react-redux';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom'
import { NavLink } from 'react-router-dom'

const Home = () => (
  <div>
    <h1>Survey</h1>
        <Button component={Link} to="/Login">
            Log In
        </Button>
        <p/>
        <Button component={Link} to="/Register">
            Register
        </Button>
  </div>
);

export default connect()(Home);
