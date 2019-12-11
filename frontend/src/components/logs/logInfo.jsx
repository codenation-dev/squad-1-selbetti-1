import React, { Component } from 'react';

import Main from "../template/main"
import api from "../../services/api"

import "./logInfo.css"

export default class logs extends Component {
    constructor(props) {
        super(props);

        this.state = {
            Log: {}
        }
    }

    async handleDelete() {
        const headers = { Authorization: 'Bearer ' + localStorage.getItem("accessToken") }

        await api.delete(`/log/${this.state.Log.id}`, { headers })
            .catch(err => {
                alert(err);
            })

        let text = window.location.href.split("#")[0];

        window.location.href = text + "#/logs"
    }

    async handleArchive() {
        const headers = { Authorization: 'Bearer ' + localStorage.getItem("accessToken") }

        await api.put(`/log/${this.state.Log.id}`, this.state.Log, { headers })
            .catch(err => {
                alert(err);
            })

        let text = window.location.href.split("#")[0];
            
        window.location.href = text + "#/logs"
    }

    async componentDidMount() {
        const { match: { params } } = this.props;
        
        const headers = { Authorization: 'Bearer ' + localStorage.getItem("accessToken") }

        const response = await api.get(`/log/${params.logId}`, { headers })
                            .catch(err => {
                                if(err.response.status === 401) {
                                    alert("Seu token de autentificação expirou...");
                                    localStorage.removeItem("accessToken");
                                    window.location.reload();
                                    return;
                                }
                            })

        this.setState( {
            Log: response.data
        } )

        console.log(this.state.Log)
      }

  render() {
    return(
        <Main>
            <div id="logInfo">
                <h2 className="PageTitle">
                    {this.state.Log.title}
                </h2>
                <aside className="logStatus">
                    {this.state.Log.level}
                </aside>
                <div className="logInfoDesc">
                    <p>
                        <strong> Detail: </strong>{this.state.Log.detail}
                    </p>
                    <p>
                        <strong> Origin: </strong>{this.state.Log.origin}
                    </p>
                    <p>
                        <strong> Environment </strong>{this.state.Log.environment}
                    </p>
                    <p>
                        <strong> Data: </strong>{new Date(this.state.Log.createdAt).toLocaleDateString()}
                    </p>
                </div>
                <div className="mt-2">
                    <button onClick={e => this.handleArchive()} type="button" class="btn btn-success">Archive</button>
                    <button onClick={e => this.handleDelete()} type="button" class="btn btn-danger">Remove</button>
                </div>
            </div>
        </Main>
    )
  }
}
