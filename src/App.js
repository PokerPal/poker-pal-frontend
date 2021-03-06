import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";
import Cookies from "universal-cookie";
import BluffBathLogo from './bluffBathLogo.png';

import './App.css';
import './Layout.css';

import {MemberProfile} from "./MemberProfile";
import {MainLeaguePage} from "./MainLeaguePage";
import {SideLeaguePage} from "./SideLeaguePage";
import {AdminOptions} from "./AdminOptions";
import {UserSettings} from "./UserSettings";
import {Dashboard} from "./Dashboard";
import {Logout} from "./Logout";

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

        <ShowNavBar />

        {/*<div className="headerRight">
          <ul className="navBar">
            <b>
              <a href="/dashboard">Dashboard</a>|
              <a href="/memberProfile">Profile</a>|
              <a href="/mainLeague">Main League</a>|
              <a href="/sideLeague">Side League</a>|
              <a href="/adminOptions">Admin Options</a>|
              <a href="/userSettings" >Settings</a>|
              <a href="/logout" >Logout</a>
            </b>
          </ul>
        </div>*/}

      </header>

      <div className="hrLine"/>

      <section className="section">
        <br/>
        <br/>
        <br/>
        <div className="main-container">

        <Router>
          <Switch>
            <Route exact path="/">
              <Dashboard />
            </Route>

            <Route exact path="/dashboard">
              <Dashboard />
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

            <Route path="/logout">
              <Logout />
            </Route>
          </Switch>
        </Router>

        </div>

      </section>
    </div>
  )
}

function ShowNavBar() {
  const cookies = new Cookies();
  let userid = cookies.get('userID')
  if (userid === 1 || userid === 7){
    return (
      <div className="headerRight">
        <ul className="navBar">
          <b>
            <a href="/dashboard">Dashboard</a>|
            <a href="/memberProfile">Profile</a>|
            <a href="/mainLeague">Main League</a>|
            <a href="/sideLeague">Side League</a>|
            <a href="/adminOptions">Admin Options</a>|
            <a href="/userSettings" >Settings</a>|
            <a href="/logout" >Logout</a>
          </b>
        </ul>
      </div>
    )
  } else {
    return (
      <div className="headerRight">
        <ul className="navBar">
          <b>
            <a href="/dashboard">Dashboard</a>|
            <a href="/memberProfile">Profile</a>|
            <a href="/mainLeague">Main League</a>|
            <a href="/sideLeague">Side League</a>|
            {/*<a href="/adminOptions">Admin Options</a>|*/}
            <a href="/userSettings" >Settings</a>|
            <a href="/logout" >Logout</a>
          </b>
        </ul>
      </div>
    )
  }

}

export default (App);