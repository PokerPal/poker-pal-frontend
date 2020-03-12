import React, { Component } from 'react';
// import { Link } from 'react-router'
// import { NativeRouter, Route, Link } from "react-router-native";
import logo from './bluffBathLogo.png';//'./logo.svg';
//bluffBathLogo.png
import './App.css';
import './Layout.css';

class Login extends Component {
    render() {
        return (
            <div className="App">
                <body>

                {/* <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" width="500" height="500" />
          <h2>Bluff Bath</h2>
        </div> */}

                {/* <div className="header1">
          <p className="App-intro">
            To get started, edit <code>src/App.js</code> and save to reload.
          </p>
        </div> */}

                <div className="custom-header">
                    {/* <h2>BLUFF BATH</h2> */}
                    <b>Bluff Bath</b>
                    {/* <h2>Bluff Bath</h2>
          <h3>Poker Society</h3> */}
                </div>

                <div className="section">
                    <div className="leftSection">
                        {/* <ul> */}
                        {/* LOGO */}
                        <img src={logo} className="App-logo" alt="logo" width="500" height="500" />
                        {/* <h2>Bluff Bath</h2> */}
                        {/* </ul> */}
                    </div>

                    <div className="rightSection">
                        <p>LOGIN </p>
                        <form className="form1">
                            <input type="text" id="fname" name="email" class="Input-box" placeholder="Email"></input>
                            <br></br><br></br>
                            <input type="password" id="pin" name="pw" class="Input-box" placeholder="Password"></input>
                            <br></br><br></br>
                            <input type="submit" value="Sign in" class="Login-button"></input>
                        </form>
                    </div>

                    {/* <div className="footer">
            <h1>
              FOOTER
            </h1>
          </div> */}
                </div>




                {/* <div className="header1">
          <h1 className="App-intro">
            Bluff Bath
          </h1>
        </div>

        <form className="form1">
          <input type="text" id="fname" name="email" class="Input-box" placeholder="Email"></input>
          <br></br><br></br>
          <input type="password" id="pin" name="pw" class="Input-box" placeholder="Password"></input>
          <br></br><br></br>
          <input type="submit" value="Sign in" class="Login-button"></input>
        </form> */}
                </body>
            </div>
        );
    }
}

// export default App;
