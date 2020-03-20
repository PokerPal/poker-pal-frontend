import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import logo from './bluffBathLogo.png';
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
                <div className="section">
                    <div className="header">

                        <div className="headerRight">
                            <h2 className="Page-header">Main League</h2>
                        </div>
                        <div className="headerLeft">
                            <img src={logo} className="App-logo-small" alt="App-logo-small"/>
                        </div>
                    </div>
                </div>
                <br />
                <script>
                    console.error("stuff")
                    var PokerPal = require('poker_pal');

                    var api = new PokerPal.BadgesApi()
                    var id = 56; {/*// {Number} The unique identifier of the badge.*/}

                    var callback = function(error, data, response) {/*{
                        if (error) {
                            console.error(error);
                        } else {
                            console.log('API called successfully. Returned data: ' + data);
                        }*/}
                    };
                    api.badgesIdGet(id, callback);
                </script>
                <Router>
                    <div className="navBar">
                        <Link to="/">  Home | </Link>
                        <Link to="/login">  Login | </Link>
                        <Link to="/memberProfile">  Profile | </Link>
                        <Link to="/mainLeague">  Main League | </Link>
                        <Link to="/sideLeague">  Side League | </Link>
                        <Link to="/adminOptions">  Admin Options | </Link>
                        <Link to="/userSettings">  User Settings </Link>
                    </div>
                    <hr />
                    <Switch>
                        <Route exact path="/">
                            <Home />
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


                <div className="section">

                    <div className="leftSection">
                        <p>

                        </p>
                    </div>
`
                    <div className="rightSection">
                        <p>LOGIN </p>
                        <ul>
                            one
                            two
                            three
                        </ul>
                    </div>

                </div>

            </div>

        );
    }
}

export default App;

function Home() {
    return (
        <div>
            <h2>Home</h2>
        </div>
    );
}

