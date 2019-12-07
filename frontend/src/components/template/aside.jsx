import React, {Component} from "react";

import BurgerMenu from "react-burger-menu"
import "./aside.css"

export default class aside extends Component {

    render() {
        const Menu = BurgerMenu["push"]
        return (
            <Menu id="push" pageWrapId={"Page-Wrapper"} outerContainerId={"App"}>
                <div>
                    <h2>
                        MENU
                    </h2>
                </div>
                <a href="#/" className="menu-item">
                    <i className={`fa fa-home mr-2`}></i> Home
                </a>
                <a href="#/login" className="menu-item">
                    <i className={`fa fa-book mr-2`}></i> Login
                </a>
                <a href="#/register" className="menu-item">
                    <i className={`fa fa-clipboard mr-2`}></i> Register
                </a>
            </Menu>
        );
    }
}
