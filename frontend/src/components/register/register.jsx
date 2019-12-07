import React, { Component } from 'react';

import Main from "../template/main"
import api from "../../services/api"

import "./register.css"

export default class register extends Component {
    state = {
        Fullname: "",
        Email: "",
        Password: "",
        ConfirmPassword: ""
    }

    handleSubmit() {

    }

    handleChange(e) {
        this.setState( {[e.target.name]: e.target.value } )
    }

    render() {
        return(
            <Main>
                <div id="RegisterScreen">
                    <h2 className="PageTitle">
                        Register
                    </h2>
                    <form onSubmit={e => this.handleSubmit()}>
                        <div className="form-group">
                            <label for="FullNameInput">Full Name</label>
                            <input onChange={e => this.handleChange(e)} name="Fullname" type="text" class="form-control" id="FullNameInput" aria-describedby="emailHelp" />
                        </div>
                        <div class="form-group">
                            <label for="EmailInput">Email address</label>
                            <input onChange={e => this.handleChange(e)} name="Email" type="email" class="form-control" id="EmailInput" aria-describedby="emailHelp" />
                        </div>
                        <div class="form-group">
                            <label for="InputPasswordRegister">Password</label>
                            <input onChange={e => this.handleChange(e)} name="Password" type="password" class="form-control" id="InputPasswordRegister" />
                        </div>
                        <div class="form-group">
                            <label for="InputConfirmPasswordRegister">Confirm Password</label>
                            <input onChange={e => this.handleChange(e)} name="ConfirmPassword"type="password" class="form-control" id="InputConfirmPasswordRegister" />
                        </div>
                        <button type="submit" class="btn btn-primary">Submit</button>
                    </form>
                </div>
            </Main>
        );
    }
}
