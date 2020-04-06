import logo from "./bluffBathLogo.png";
import React, {Component} from "react";
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import {MainLeaguePage} from "./MainLeaguePage";

import Autosuggest from 'react-autosuggest';
import Cookies from "universal-cookie";



export function AdminOptions() {
  return (
    <div>
      {/*<GetUNamesFromBE/>*/}

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
      <br/>
      ADMIN OPTIONS <br/> <br/>
      <label className="adminButtons"><a href="/adminOptions/enterMainLeague">Enter places in Main League</a></label> <br/> <br/>
      <label className="adminButtons"><a href="/adminOptions/enterSideLeague">Enter in/out in Side League</a></label> <br/> <br/>
      <b>FINISHED SESSION BUTTON HERE</b>
      <br/>
    </div>
  )
}

function EnterMainLeagueData() {
  return(
    <div>
      <NameAndPlace/>
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

function GetUNamesFromBE() {
  let request = new XMLHttpRequest();
  request.open('GET', "http://localhost:5000/users", false);
  let dataReturn;
  request.onload = function () {
    let data = JSON.parse(this.response);
    if (data.error == null) {
      let numEntries = data.value.length; // how many users
      console.log(data.value);
      console.log(data.value[0].name);
      dataReturn = data.value;
      return data.value;
    }
  };
  request.send();
  console.log("fart");
  return dataReturn;
}

const userNames = GetUNamesFromBE();
console.log("userNames:",userNames);


// Teach Autosuggest how to calculate suggestions for any given input value.
const getSuggestions = value => {
  const inputValue = value.trim().toLowerCase();
  const inputLength = inputValue.length;

  return inputLength === 0 ? [] : userNames.filter(lang =>
    lang.name.toLowerCase().slice(0, inputLength) === inputValue
  );
};

// When suggestion is clicked, Autosuggest needs to populate the input
// based on the clicked suggestion. Teach Autosuggest how to calculate the
// input value for every given suggestion.
const getSuggestionValue = suggestion => suggestion.name;

// Use your imagination to render suggestions.
const renderSuggestion = suggestion => (
  <div>
    {suggestion.name}
  </div>
);

class NameAndPlace extends Component {
  constructor(props) {
    super(props);
    this.state = {
      username: '',
      place: '',
      value: '',
      suggestions: []
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.onChange = this.onChange.bind(this);
    this.onSuggestionsFetchRequested = this.onSuggestionsFetchRequested.bind(this);
    this.onSuggestionsClearRequested = this.onSuggestionsClearRequested.bind(this);

  }

  onChange = (event, { newValue }) => {
    this.setState({
      value: newValue
    });
  };

  // Autosuggest will call this function every time you need to update suggestions.
  // You already implemented this logic above, so just use it.
  onSuggestionsFetchRequested = ({ value }) => {
    this.setState({
      suggestions: getSuggestions(value)
    });
  };

  // Autosuggest will call this function every time you need to clear suggestions.
  onSuggestionsClearRequested = () => {
    this.setState({
      suggestions: []
    });
  };

  handleChange(event) { // FROM LOGIN
    this.setState({ [event.target.name]: event.target.value});
    /*this.setState({value1: event.target.value1});*/ // KEEP ME FOR REFERENCE
  }

  handleSubmit(event) {
    let valid = true;
    if (this.state.value.length === 0
      || this.state.place.length === 0) {
      window.alert("Please fill in all fields");
      valid = false;
    }

    event.preventDefault();
    if (valid) {
      /*console.log(this.state.place);
      console.log(this.state.value);*/
      SendToBackEnd(this.state.value, this.state.place)

    }

  }

  render() {
    const { value, suggestions } = this.state;

    // Autosuggest will pass through all these props to the input.
    const inputProps = {
      placeholder: 'Enter a username',
      value,
      onChange: this.onChange,
      className: 'Input-box'
    };

    return (
      <div>
        <br/>
        <p><b>Enter Name and place</b></p>
        <form onSubmit={this.handleSubmit}>
          <Autosuggest
            suggestions={suggestions}
            onSuggestionsFetchRequested={this.onSuggestionsFetchRequested}
            onSuggestionsClearRequested={this.onSuggestionsClearRequested}
            getSuggestionValue={getSuggestionValue}
            renderSuggestion={renderSuggestion}
            inputProps={inputProps}
          />
          <input type="number" name="place" className="Input-box" placeholder="Place" value={this.state.place} onChange={this.handleChange}/> <br/> <br/>
          <button type="submit" value="Submit" className="Login-button">Submit</button>
        </form>
      </div>
    );
  }

}

function SendToBackEnd(un,place) {
  console.log("STUFF TO SEND TO BACKEND");
  console.log(un);
  console.log(place)
}

