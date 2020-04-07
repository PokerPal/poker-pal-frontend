import logo from "./bluffBathLogo.png";
import React, {Component} from "react";
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";

/*import Redirect from "react-router-dom/es/Redirect";*/
import {MainLeaguePage} from "./MainLeaguePage";

import Autosuggest from 'react-autosuggest';

import Cookies from "universal-cookie";
import {SLI} from './SLI'
import {MLI} from "./MLI";
import {StartNewSession} from "./StartNewSession";
import {StartNewLeague} from "./StartNewLeague";


export function AdminOptions() {
  return (
    <div>

      <Router>
        <Switch>
          <Route exact path="/adminOptions">
            <MainScreen />
          </Route>

          <Route exact path="/adminOptions/createNewSession">
            <StartNewSession />
          </Route>

          <Route exact path="/adminOptions/createNewLeague">
            <StartNewLeague />
          </Route>

        </Switch>
      </Router>

    </div>


  );
}

function MainScreen() {
  return(
    <div>
      <br/>
      <div className="adminLeftSection">
        <div>
          <p><b>ADMIN OPTIONS</b></p> <br/>

          <div className="break-line"/> <br/>

          <label className="adminButtons"><a href="/adminOptions/createNewSession">Create New Session</a></label> <br/> <br/>
          <CurrentSessionID/>
          <button type="submit" value="Submit" className="Login-button" onClick={EndSession}>Finish Session</button> <br/> <br/>

          <div className="break-line-right"/> <br/>

          <label className="adminButtons"><a href="/adminOptions/createNewLeague">Create New League</a></label> <br/> <br/>

          {/*<label className="adminButtons"><a href="/adminOptions/createNewLeague">Delete User </a></label> <br/> <br/>*/}

        </div>
      </div>

      <div className="adminRightSection">
        <DisplayLIs/>
      </div>

      <br/>
    </div>
  )
}

function EndSession() {
  const cookies = new Cookies();
  let seshID = cookies.get('sessionID');

  const method = "POST";
  const url = "http://localhost:5000/sessions/" + seshID + "/finalize";

  let request = new XMLHttpRequest();
  request.open(method, url, true);
  request.setRequestHeader('Content-type', 'application/json');
  request.onload = function(){
    console.log(request.responseText)

  };
  request.send();

  cookies.remove('sessionID');
  console.log("cookie val: ", cookies.get('seshID'));

  window.location.reload(true)
}

/**
 * @return {null}
 */
function DisplayLIs() {
  const cookies = new Cookies();
  let MainSeshID = cookies.get('mainSessionID');
  let SideSeshID = cookies.get('sideSessionID');
  /*console.log("seshID: ",seshID);*/
  if (MainSeshID !== undefined && SideSeshID !== undefined){
    return (
      <div>
        <MLI/>
        <br/><div className="break-line-left"/>
        <SLI/>
        <br/>
      </div>
    )
  } else if (MainSeshID !== undefined && SideSeshID === undefined) {
    return (
      <div>
        <MLI/>
        <br/><div className="break-line-left"/>

        <br/>
      </div>
    )
  } else if (MainSeshID === undefined && SideSeshID !== undefined) {
    return (
      <div>

        <br/><div className="break-line-left"/>
        <SLI/>
        <br/>
      </div>
    )
  } else{
    return null
  }
}

function CurrentSessionID() {
  const cookies = new Cookies();
  let MseshID = cookies.get('mainSessionID');
  let SseshID = cookies.get('sideSessionID');
  console.log("MseshID: ",MseshID);
  console.log("SseshID: ",SseshID);
  if (MseshID === undefined){
    MseshID = "No Session in Current Use"
  }
  if (SseshID === undefined){
    SseshID = "No Session in Current Use"
  }
  return (
    <div>
      <p>Current Main League Session ID: {MseshID}</p>
      <p>Current Side League Session ID: {SseshID}</p>
    </div>
  )
}
