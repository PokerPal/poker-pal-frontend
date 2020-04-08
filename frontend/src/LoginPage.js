import logo from "./bluffBathLogo.png";
import React, {Component} from "react";
import { useCookies } from 'react-cookie';
import Cookies from 'universal-cookie';

import "./slider.css";
import "./App.css";
import "./Layout.css";
import App from "./App";


export function LoginPage() {
    return (
        <div className="App">

            <LoginForm/>

        </div>
    );
}

class LoginForm extends Component {
    constructor(props) {
        super(props);
        this.handleChangeToLogin = this.handleChangeToLogin.bind(this);
        this.handleChangeToRegister = this.handleChangeToRegister.bind(this);
        this.state = {
            isLoggedIn: false,
            needToRegister: false,

            username: '',
            password: '',

            firstName: '',
            lastName: '',
            newUsername: '',
            newPassword: '',
            confirmPassword: '',
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleLoginSubmit = this.handleLoginSubmit.bind(this);
        this.handleRegisterSubmit = this.handleRegisterSubmit.bind(this);
    }

    handleChangeToLogin() {
        this.setState({needToRegister: false});
    }

    handleChangeToRegister() {
        this.setState({needToRegister: true});
    }

    handleChange(event) { // doing anything?
        this.setState({[event.target.name]: event.target.value});
        /*this.setState({value1: event.target.value1});*/ // KEEP ME FOR REFERENCE
    }

    handleLoginSubmit(event) {
        console.log("username: " + this.state.username);
        console.log("password: " + this.state.password);

        let valid = true;
        if (this.state.username.length === 0
          || this.state.password.length === 0) {
            window.alert("Please fill in all fields");
            valid = false;
        }

        let email = this.state.username;
        let username = email.split('@')[0];
        if (email.length !== username.length) {
            this.state.username = username;
        }

        event.preventDefault();
        if (valid) {
            let pars = "{" +
              "\"email\": \""+ this.state.username +"@bath.ac.uk\", " +
              "\"password\": \""+this.state.password+"\"" +
              "}";
            console.log(pars);
            let res = LoginRequest(pars);
            console.log("res: ",res);
            if(res){
                console.log("success innit ");
                this.setState({isLoggedIn:true})
            }


            /*this.setState({isLoggedIn:true})*/
        }

        /*this.setState({isLoggedIn:true})*/

    }

    handleRegisterSubmit(event) {
        event.preventDefault();
        let valid = true;
        if (this.state.firstName.length === 0
          || this.state.lastName.length === 0
          || this.state.newUsername.length === 0
          || this.state.newPassword.length === 0) {
            window.alert("Please fill in all fields");
            this.state.newPassword = '';
            this.state.confirmPassword = '';
            valid = false;

        }
        if (this.state.newPassword !== this.state.confirmPassword){
            window.alert("Passwords do not match");
            this.state.newPassword = '';
            this.state.confirmPassword = '';
            valid = false;
        }

        if (valid) {
            let pars = "{" +
              "\"email\":\"" + this.state.username + "@bath.ac.uk\"," +
              "\"name\":\"" + this.state.firstName + " " + this.state.lastName + "\"," +
              "\"password\":\"" + this.state.newPassword + "\"" +
              "}";
            console.log(pars);

            const method = "POST";
            const url = "http://localhost:5000/users";

            let request = new XMLHttpRequest();
            request.open(method, url, true);
            request.setRequestHeader('Content-type', 'application/json');
            request.onload = function () {
                console.log(request.responseText);
                let response = JSON.parse(this.response);
                console.log("response: ",response.error);
                /*{"value":{"id":9},"error":null,"isOk":true}*/
                if(response.error===null){
                    console.log("sign up success");
                    alert("sign up success");
                }
            };
            request.send(pars);
        }
    }


    render() {

        let button;
        if (this.state.needToRegister) {
            button = <RegisterButton onClick={this.handleChangeToLogin} />;
        } else {
            button = <LoginButton onClick={this.handleChangeToRegister} />;
        }

        if (!this.state.isLoggedIn){
            if (this.state.needToRegister){
                return (
                  <div>
                      <div className="custom-header">
                          <b>Bluff Bath</b>
                      </div>
                      <div className="section">
                          <div className="leftSection">
                              <img src={logo} className="App-logo-large" alt="logo" />
                          </div>

                          <div className="rightSection">
                              {button}
                              <p><b>REGISTER</b></p>
                              <form onSubmit={this.handleRegisterSubmit}>
                                  <input type="text" name="firstName" className="Input-box" placeholder="First Name" value={this.state.firstName} onChange={this.handleChange}/> <br/>
                                  <input type="text" name="lastName" className="Input-box" placeholder="Last Name" value={this.state.lastName} onChange={this.handleChange}/> <br/>
                                  <input type="text" name="newUsername" className="Input-box" placeholder="Bath username" value={this.state.newUsername} onChange={this.handleChange}/> <br/>
                                  <input type="password" name="newPassword" className="Input-box" placeholder="Password" value={this.state.newPassword} onChange={this.handleChange}/> <br/>
                                  <input type="password" name="confirmPassword" className="Input-box" placeholder="Confirm Password" value={this.state.confirmPassword} onChange={this.handleChange}/> <br/> <br/>
                                  <button type="submit" value="Submit" className="Login-button" >Register</button>
                              </form>
                          </div>

                      </div>

                  </div>
                )
            }else {
                return (
                  <div>

                      <div className="custom-header">
                          <b>Bluff Bath</b>
                      </div>

                      <div className="section">

                          <div className="leftSection">
                              <img src={logo} className="App-logo-large" alt="logo" />
                          </div>

                          <div className="rightSection">
                              {button}
                              <p><b>LOGIN</b></p>
                              <form onSubmit={this.handleLoginSubmit}>
                                  <input type="text" name="username" className="Input-box" placeholder="Bath username"
                                         value={this.state.username} onChange={this.handleChange}/> <br/>
                                  <input type="password" name="password" className="Input-box" placeholder="Password"
                                         value={this.state.password} onChange={this.handleChange}/> <br/> <br/>
                                  <button type="submit" value="Submit" className="Login-button">Login</button>
                              </form>
                          </div>

                      </div>

                  </div>
                )
            }
        }

        else {
            return (
              <App/>
            );
        }
    }
}

function LoginButton(props) {
    return (
      <div>
          Login
          <label className="switch">
              <input type="checkbox" id="logRegToggle" onClick={props.onClick} />
              <span className="slider round"/>
          </label>
          Register
      </div>
    );
}

function RegisterButton(props) {
    return (
      <div>
          Login
          <label className="switch">
              <input type="checkbox" checked={true} id="logRegToggle" onClick={props.onClick} />
              <span className="slider round"/>
          </label>
          Register
      </div>

    );
}

/**
 * @return {boolean}
 */
function LoginRequest(pars) {
    const method = "POST";
    const url = "http://localhost:5000/users/logIn";

    let request = new XMLHttpRequest();
    request.open(method, url, true);
    request.setRequestHeader('Content-type', 'application/json');
    request.onload = function () {
        let data = JSON.parse(this.response);
        console.log("data: ", data);
        if (data.error == null) {
            const cookies = new Cookies();
            cookies.set('userName', data.value.email.split('@')[0], {path: '/'});
            cookies.set('userID', data.value.id, {path: '/'});
            console.log("login success");
            console.log("request.status: ", request.status);
            return true;
        } else {
            alert(data.error);
            return false;
        }
    };
    request.send(pars);

    if (request.status === 200) {
        console.log("wooo");
        return true
    }else{
        console.log("ooow");
        console.log(request.status);
        console.log("request.onload: ", request.onload);
        return false
    }

    /*while (!(request.status===200) || !(request.status>=400)){
        console.log("waiting")
    }
    console.log("done waiting")*/

}