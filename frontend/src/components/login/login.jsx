import React, { Component } from 'react';

import Main from "../template/main"
import api from "../../services/api"

import "./login.css"

export default class login extends Component {
  state = {
    Email: "",
    Password: "",
  }

  handleChange(e) {
      this.setState( {[e.target.name]: e.target.value } )
  }

  handleSubmit() {

  }

  render() {
    return (
        <Main>
            <div id="LoginScreen">
              <h2 className="PageTitle">
                Login
              </h2>
              <form onSubmit={e => this.handleSubmit()}>
                    <div className="form-group">
                        <label for="EmailInputLogin">Email address</label>
                        <input onChange={e => this.handleChange(e)} name="Email" type="email" class="form-control" id="EmailInputLogin" aria-describedby="emailHelp" />
                    </div>
                    <div class="form-group">
                        <label for="PasswordInputLogin">Password</label>
                        <input onChange={e => this.handleChange(e)} name="Password" type="password" class="form-control" id="PasswordInputLogin" />
                    </div>
                    <button type="submit" class="btn btn-primary">Submit</button>
                </form>
            </div>
        </Main>
    );
  }
}
