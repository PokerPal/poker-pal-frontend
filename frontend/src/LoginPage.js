import logo from "./bluffBathLogo.png";
import React, {Component} from "react";
import "./slider.css";
import "./App.css";
import "./Layout.css";

export function LoginPage() {
    return (
        <div className="App">

            <div className="custom-header">
                <b>Bluff Bath</b>
            </div>

            <div className="section">

                <div className="leftSection">
                    <img src={logo} className="App-logo-large" alt="logo" />
                </div>

                <div className="rightSection">
                    <LoginControl/>
                </div>

            </div>
        </div>
    );
}

class LoginControl extends React.Component {
    constructor(props) {
        super(props);
        this.handleChangeToLogin = this.handleChangeToLogin.bind(this);
        this.handleChangeToRegister = this.handleChangeToRegister.bind(this);
        this.state = {isLoggedIn: false};
    }

    handleChangeToLogin() {
        this.setState({isLoggedIn: true});
    }

    handleChangeToRegister() {
        this.setState({isLoggedIn: false});
    }

    render() {
        const isLoggedIn = this.state.isLoggedIn;
        let button;
        if (isLoggedIn) {
            button = <RegisterButton onClick={this.handleChangeToRegister} />;
        } else {
            button = <LoginButton onClick={this.handleChangeToLogin} />;
        }

        return (
            <div>
                {button}
                <Greeting isLoggedIn={!isLoggedIn} />
            </div>
        );
    }
}

function Greeting(props) {
    const isLoggedIn = props.isLoggedIn;
    if (isLoggedIn) {
        return <LoginForm/>;
    }
    return <RegisterForm/>;
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
        /*this.setState({value1: event.target.value1});*/ // KEEP ME FOR REFERENCE
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

class LoginForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value});
        /*this.setState({value1: event.target.value1});*/ // KEEP ME FOR REFERENCE
    }

    handleSubmit(event) {
        console.log("username: " + this.state.username);
        console.log("password: " + this.state.password);

        // TODO password stuff when added to API
        let valid = true;
        if (this.state.username.length === 0
            || this.state.password.length === 0) {
            window.alert("Please fill in all fields");
            valid = false;
        }

        event.preventDefault();
        if (valid) { // TODO passwords should most probably be encrypted somehow before here
            Login("{" +
                "\"email\":\""+ this.state.username +"@bath.ac.uk\"," +
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
                <p><b>LOGIN</b></p>
                <form onSubmit={this.handleSubmit}>
                    <input type="text" name="username" className="Input-box" placeholder="Bath username" value={this.state.username} onChange={this.handleChange}/> <br/>
                    <input type="password" name="password" className="Input-box" placeholder="Password" value={this.state.password} onChange={this.handleChange}/> <br/> <br/>
                    <button type="submit" value="Submit" className="Login-button">Login</button>
                </form>
            </div>
        );
    }

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