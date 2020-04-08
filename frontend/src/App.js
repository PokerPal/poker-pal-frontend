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

export default (App);

/*function Dashboard() {
    return (
        <div>
            <h2>Dashboard</h2>
        </div>
    );
}*/

/**
 * @return {null}
 */
function CookieTest() {
  const cookies = new Cookies();
  cookies.set('myCat', 'Pacman', { path: '/' });
  console.log(cookies.get('myCat')); // Pacman

  return null;
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
              <a href="/">Dashboard</a>|
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

      <CookieTest/>

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

        </div>

      </section>
    </div>
  )
}