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

let ContentToSee = <div> </div>;

class App extends Component {
    render() {
        return (
            <div className="universalTextColour">

                <div className="section">
                    <div className="header">

                        <div className="headerLeft">
                            <img src={logo} className="App-logo-small" alt="App-logo-small"/>
                        </div>

                        <div className="headerRight">
                            {/*<h2 className="Page-header">Main League</h2>*/}
                            <Switcher/>
                        </div>

                    </div>
                </div>

                <hr />


                {/*<ContentToSee/>*/}
                <ContentChange/>



                <div className="section">

                    <div className="leftSection">
                        <p>

                        </p>
                    </div>

                    {/*TODO sort layout stuff*/}
                    {/*<div className="rightSection">
                        <p>LOGIN </p>
                        <ul>
                            one
                            two
                            three
                        </ul>
                    </div>*/}

                </div>

            </div>

        );
    }
}

export default App;

function ContentChange(props){
    console.log(props.thing);
    if (props.thing==="LoginPage") {
        ContentToSee = <LoginPage/>;
    }else if (props.thing==="MemberProfile") {

    }


    return (ContentToSee)
}

function Switcher(){
    return(
        <div>
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
            {/*<hr />*/}
            <Switch>
                <Route exact path="/">
                    <Home />
                </Route>

                <Route path="/login">
                    {/*<LoginPage />*/}
                    <ContentChange thing="LoginPage"/>
                    {/*<ContentChange toSee={LoginPage}/>*/}
                </Route>

                <Route path="/memberProfile">
                    <ContentChange thing="fart"/>
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
        </div>
    )
}



function Home() {
    return (
        <div>
            <h2>Home</h2>
        </div>
    );
}

