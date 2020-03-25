import logo from "./bluffBathLogo.png";
import React, {Component} from "react";
import "./slider.css";

import {RegisterPage} from './RegisterPage';

class RegisterForm extends Component {
    constructor(props) {
        super(props);
        this.state = {firstName: '',
            lastName: '',
            username: '',
            password: '',
            confirmPassword: '',
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value});
        /*this.setState({value1: event.target.value1}); // KEEP ME FOR REFERENCE
        this.setState({value2: event.target.value2});*/
    }

    handleSubmit(event) {
        console.log("firstName: " + this.state.firstName);
        console.log("lastName: " + this.state.lastName);
        console.log("username: " + this.state.username);
        console.log("password: " + this.state.password);
        console.log("confirmPassword: " + this.state.confirmPassword);
        // TODO input validation - here?
        console.log(this.state.firstName.length);
        let valid = true;
        if (this.state.firstName.length === 0
            || this.state.lastName.length === 0
            || this.state.username.length === 0
            || this.state.password.length === 0) {
            window.alert("Please fill in all fields");
            valid = false;

        }
        if (this.state.password !== this.state.confirmPassword){
            window.alert("Passwords do not match");
            valid = false;
        }
        event.preventDefault();
        if (valid) { // TODO passwords should most probably be encrypted somehow before here
            Register("{" +
                "\"email\":\""+ this.state.username +"@bath.ac.uk\"," +
                "\"name\":\""+this.state.firstName+" "+this.state.lastName+"\"," +
                "\"password\":\""+this.state.password+"\"" +
                "}");
        }/*else{ // TODO clear passwords on invalid input?
            this.state.password = '';
            this.state.confirmPassword = '';
        }*/

    }

    render() {
        return (
            <div>
                <p><b>REGISTER</b></p>
                <form onSubmit={this.handleSubmit}>
                    <input type="text" name="firstName" className="Input-box" placeholder="First Name" value={this.state.firstName} onChange={this.handleChange}/> <br/>
                    <input type="text" name="lastName" className="Input-box" placeholder="Last Name" value={this.state.lastName} onChange={this.handleChange}/> <br/>
                    <input type="text" name="username" className="Input-box" placeholder="Bath username" value={this.state.username} onChange={this.handleChange}/> <br/>
                    <input type="password" name="password" className="Input-box" placeholder="Password" value={this.state.password} onChange={this.handleChange}/> <br/>
                    <input type="password" name="confirmPassword" className="Input-box" placeholder="Confirm Password" value={this.state.confirmPassword} onChange={this.handleChange}/> <br/> <br/>
                    <button type="submit" value="Submit" className="Login-button" >Register</button>
                </form>
            </div>
        );
    }

}


export function LoginPage() {
    return (
        <div className="App">

                <div className="custom-header">
                    <b>Bluff Bath</b>
                </div>

                <div className="section">
                    <div className="leftSection">
                        <img src={logo} className="App-logo-large" alt="logo" width="500" height="500" />
                    </div>

                    <div className="rightSection">
                        Login
                        <label className="switch">
                            <input type="checkbox" id="logRegToggle" onClick={Toggle}  />
                            <span className="slider round"/>
                        </label>
                        {/*<button onClick={Toggle}> switch </button>*/}
                        Register

                        <RegisterForm/>

                        {/*<RegisterUI />
                        <LoginUI />*/}

                    </div>
                </div>
        </div>
    );
}

function Toggle(){
    console.log("fart");
    return (LoginUI)
}


function RegisterUI(){
    return (
        <div>
            <p><b>REGISTER</b></p>
            <form className="form1">
                <input type="text" id="fname" className="Input-box" placeholder="First Name"/> <br/>
                <input type="text" id="lname" className="Input-box" placeholder="Last Name"/> <br/>
                <input type="text" id="username" className="Input-box" placeholder="Bath username"/> <br/>
                <input type="password" id="password" className="Input-box" placeholder="Password"/> <br/>
                <input type="password" id="confirmPassword" className="Input-box" placeholder="Confirm Password"/>
                <br/><br/>
                <button type="button"  className="Login-button" onClick={Register()}>Register</button> {/*onClick={Register()}*/}
            </form>
        </div>
    );
}


function Register(pars) {
    console.log("REGISTER");
    console.log(pars);

    const method = "POST";
    const url = "https://localhost:5001/users";
    let params = "{" +
        "\"email\": \"fart2@farty.com\"," +
        "\"name\": \"asdf2\"," +
        "\"password\": \"asdfasdf2\"" +
        "}";
    params = pars;
    let request = new XMLHttpRequest();
    request.open(method, url, true);
    request.setRequestHeader('Content-type', 'application/json');
    request.onload = function(){
        console.log(request.responseText)
    };
    request.send(params)

}

function LoginUI(){
    return (
        <div>
            <p><b>LOGIN</b></p>
            <form className="form1">
                <input type="text" id="user" className="Input-box" placeholder="Email"/>
                <br/><br/>
                <input type="password" id="pass" className="Input-box" placeholder="Password"/>
                <br/><br/>
                <button type="button"  className="Login-button" onClick={Login}>Sign in</button>
            </form>
        </div>
    );
}

function Login() {
    var request = new XMLHttpRequest();
    request.open('GET', "https://localhost:5001/users/1");
    request.onload = function(){
        var data = JSON.parse(this.response);
        if (data.error == null) {
            console.log(data.value.id);
            console.log(data.value.name);
            console.log(data.value.email);
            console.log(data.value.joined);
            console.log(data.value.authLevel);
        }

    };
    request.send();

}