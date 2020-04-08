import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    Redirect
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
import {TournDataIn} from "./TournDataIn";
import {Dashboard} from "./Dashboard";

import Cookies from 'universal-cookie';

class App extends Component {
    render() {
        return (
            <div className="universalTextColour">

              <HomeContainer/>

            </div>
        );
    }
}

function HomeContainer(){
  return (
    <div>
      <header>
        <div className="headerLeft">
          <img src={BluffBathLogo} className="App-logo-small" alt="App-logo-small"/>
        </div>

        <div className="headerRight">
          <ul className="navBar">
            <b>
              <a href="/dashboard">Dashboard</a>|
              <a href="/login">Login</a>|
              <a href="/memberProfile">Profile</a>|
              <a href="/mainLeague">Main League</a>|
              <a href="/sideLeague">Side League</a>|
              <a href="/adminOptions">Admin Options</a>|
              {/*<a href="/tournDataIn" >Tournament Data Input</a>|*/}
              <a href="/userSettings" >Settings</a>
            </b>
          </ul>
        </div>

      </header>

      <div className="hrLine"/>

      <section className="section">

        <Router>
          <Switch>
            <Route exact path="/dashboard">
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

            <Route path="/tournDataIn">
              <TournDataIn />
            </Route>

            <Route path="/userSettings">
              <UserSettings />
            </Route>
          </Switch>
        </Router>

      </section>
    </div>
  )
}


export default (App);