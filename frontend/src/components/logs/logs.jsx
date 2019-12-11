import React, { Component } from 'react';

import api from "../../services/api"
import Main from "../template/main"
import "./log.css"
import "./logs.css"

export default class logs extends Component {
  constructor(props) {
    super(props);

    this.state = {
      Logs: [],
      isChecked: false
    }
  }

  async handleGetLogs() {
    const headers = { Authorization: 'Bearer ' + localStorage.getItem("accessToken") }

    return await api.get("/log",{ headers })
      .catch(err => {
        if(err.response.status === 401) {
          alert("Seu token de autentificação expirou...");
          localStorage.removeItem("accessToken");
          window.location.reload();
          return;
        }
      })
  }

  async componentDidMount() {

    const response = await this.handleGetLogs();
    
    await this.setState({
      Logs: response.data
    })
    
  }

  async handleCheck(e) {

    await this.setState({
      isChecked: e.target.checked,
      logEl: []
    })
    this.forceUpdate();

  }

  verifyCheck(e) {
    if(e.target.checked) this.state.selected.push(e.target.name)
  }

  handleDeleteAll() {
    if(!this.state.isChecked) return

    const Logs = this.state.Logs.map(el => el.id)

    const headers = { Authorization: 'Bearer ' + localStorage.getItem("accessToken") }

    Logs.map(async el =>  {
      await api.delete(`/log/${el}`, { headers })
    })

  }

  handleArchiveAll() {
    if(!this.state.isChecked) return

    const Logs = this.state.Logs.map(el => el.id)

    const headers = { Authorization: 'Bearer ' + localStorage.getItem("accessToken") }

    Logs.map(async el =>  {
      await api.put(`/log/${el}`, {}, { headers })
    })

  }

  handleLogChange(id) {
    window.location.href += "/" + id;
  }

  render() {
    return(
        <Main>
            <div id="LogsScreen">
              <h2 className="PageTitle">
                Logs
              </h2>
              <div className="options">
                <div class="form-check">
                  <input onChange={e => this.handleCheck(e)} type="checkbox" class="form-check-input" id="exampleCheck1" />
                  <label class="form-check-label" for="exampleCheck1">Select All</label>
                </div>
                <button type="button" class="btn btn-success">Archive</button>
                <button onClick={e => this.handleDeleteAll(e)} type="button" class="btn btn-danger">Remove</button>
              </div>
              {this.state.Logs.map(el => (
                <div className="log" onClick={e => this.handleLogChange(el.id)}>
                  <div className="logCheck">
                    <div className="form-check">
                      <input name={el.id} type="checkbox" className="form-check-input" id="exampleCheck1" checked={this.state.isChecked}/>
                      <label className="form-check-label" htmlFor="exampleCheck1"></label>
                    </div>
                  </div>
                  <aside className="logStatus">
                    {el.level}
                  </aside>
                  <div className="logDesc">
                    <div>{el.title}</div>
                    <div>{el.origin}</div>
                    <div>{el.createdAt}</div>
                  </div>
                </div>
              ))}
            </div>
        </Main>
    );
  }
}
