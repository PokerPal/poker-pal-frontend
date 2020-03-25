import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import BluffBathLogo from './bluffBathLogo.png';
import './App.css';
import './Layout.css';
import {LoginPage} from "./LoginPage";
import {MemberProfile} from "./MemberProfile";
import {MainLeaguePage} from "./MainLeaguePage";
import {SideLeaguePage} from "./SideLeaguePage";
import {AdminOptions} from "./AdminOptions";
import {UserSettings} from "./UserSettings";

class App extends Component {
    render() {
        return (
            <div className="universalTextColour">
                <header>
                    <div className="headerLeft">
                        <img src={BluffBathLogo} className="App-logo-small" alt="App-logo-small"/>
                    </div>

                    <div className="headerRight">
                        <ul className="navBar">
                            <a href="/">Dashboard | </a>
                            <a href="/login">Login | </a>
                            <a href="/memberProfile">Profile | </a>
                            <a href="/mainLeague">Main League | </a>
                            <a href="/sideLeague">Side League | </a>
                            <a href="/adminOptions">Admin options | </a>
                            <a href="/userSettings">Settings </a>
                        </ul>
                    </div>

                </header>

                <div className="hrLine"/>

                <container className="section">

                    <Router>
                        <Switch>
                            <Route exact path="/">
                                <Dashboard />
                            </Route>

                            <Route path="/login">
                                <LoginPage />
                            </Route>

                            <Route path="/memberProfile">
                                <MemberProfile />
                            </Route>

                            <Route path="/mainLeague">
                                <MainLeaguePage />
                            </Route>

                            <Route path="/sideLeague">
                                <SideLeaguePage />
                            </Route>

                            <Route path="/adminOptions">
                                <AdminOptions />
                            </Route>

                            <Route path="/userSettings">
                                <UserSettings />
                            </Route>
                        </Switch>
                    </Router>

                </container>
            </div>

        );
    }
}

export default App;

function Dashboard() {
    return (
        <div>
            <h2>Dashboard</h2>
        </div>
    );
}

