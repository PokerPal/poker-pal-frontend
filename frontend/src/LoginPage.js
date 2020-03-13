import logo from "./bluffBathLogo.png";
import React from "react";

export function LoginPage() {
    return (
        <div className="App">
            <body>

                <div className="custom-header">
                    <b>Bluff Bath</b>
                </div>

                <div className="section">
                    <div className="leftSection">
                        <img src={logo} className="App-logo" alt="logo" width="500" height="500" />
                    </div>

                    <div className="rightSection">
                        <p>LOGIN</p>
                        <form className="form1">
                            <input type="text" id="fname" name="email" className="Input-box" placeholder="Email"/>
                            <br/><br/>
                            <input type="password" id="pin" name="pw" className="Input-box" placeholder="Password"/>
                            <br/><br/>
                            <input type="submit" value="Sign in" className="Login-button"/>
                        </form>
                    </div>
                </div>
            </body>
        </div>
    );
}