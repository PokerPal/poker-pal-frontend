import logo from "./bluffBathLogo.png";
import React from "react";
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import {MainLeaguePage} from "./MainLeaguePage";


export function AdminOptions() {
  return (
    <div>


      <Router>
        <Switch>
          <Route exact path="/adminOptions">
            <MainScreen />
          </Route>

          <Route exact path="/adminOptions/enterMainLeague">
            <EnterMainLeagueData />
          </Route>

          <Route exact path="/adminOptions/enterSideLeague">
            <EnterSideLeagueData />
          </Route>

        </Switch>
      </Router>

    </div>


  );
}

function MainScreen() {
  return(
    <div>
      ADMIN OPTIONS
      <input type="button"/><label className="adminButtons"><a href="/adminOptions/enterMainLeague">Enter places in main league</a></label>
      <input type="button"/><label className="adminButtons"><a href="/adminOptions/enterSideLeague">Enter in/out in side league</a></label>
      <br/>
    </div>
  )
}

function EnterMainLeagueData() {
  return(
    <div>
      Enter Main League Data
    </div>
  )
}

function EnterSideLeagueData() {
  return(
    <div>
      Enter Side League Data
    </div>
  )
}