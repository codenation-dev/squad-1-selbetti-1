import React from 'react';
import { Switch, Route, Redirect } from "react-router";

import Home from "../components/home/home";
import Login from "../components/login/login";
import Register from "../components/register/register";
import notFound from "../components/notFound/notFound"
// import { Container } from './styles';

export default function login() {
  return (
    <Switch>
        <Route exact path="/" component={Home}/>
        <Route path="/login" component={Login} />
        <Route path="/register" component={Register} />
        <Route path="*" component={notFound} />
    </Switch>
  );
}
