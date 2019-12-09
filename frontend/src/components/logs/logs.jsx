import React, { Component } from 'react';

import api from "../../services/api"
import Main from "../template/main"
import "./logs.css"

export default class logs extends Component {
  render() {
    return(
        <Main>
            <div id="LogsScreen">
              <h2 className="PageTitle">
                Logs
              </h2>
            </div>
        </Main>
    );
  }
}
