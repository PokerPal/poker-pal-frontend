import logo from "./bluffBathLogo.png";
import React from "react";
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import {MainLeaguePage} from "./MainLeaguePage";

import Autosuggest from 'react-autosuggest';



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
      ADMIN OPTIONS <br/> <br/>
      <label className="adminButtons"><a href="/adminOptions/enterMainLeague">Enter places in main league</a></label> <br/> <br/>
      <label className="adminButtons"><a href="/adminOptions/enterSideLeague">Enter in/out in side league</a></label> <br/> <br/>
      <br/>
    </div>
  )
}

function EnterMainLeagueData() {
  return(
    <div>
      <Example/>
    </div>
  )
}

/*
const languages = [
  {
    name: 'C',
    year: 1972
  },
  {
    name: 'Elm',
    year: 2012
  },
];
*/

const languages = [
  {name: "ja853"},
  {name: "ja853"},
  {name: "ja853"},
  {name: "ja853"},
  {name: "ja853"},
  {name: "ja853"},
  {name: "lsg38"},
  {name: "jm2787"},
  {name: "snm48"},
  {name: "oof26"},
  {name: "sr2058"},
  {name: "gjcr20"}
];

// Teach Autosuggest how to calculate suggestions for any given input value.
const getSuggestions = value => {
  const inputValue = value.trim().toLowerCase();
  const inputLength = inputValue.length;

  return inputLength === 0 ? [] : languages.filter(lang =>
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

class Example extends React.Component {
  constructor(props) {
    super(props);

    // Autosuggest is a controlled component.
    // This means that you need to provide an input value
    // and an onChange handler that updates this value (see below).
    // Suggestions also need to be provided to the Autosuggest,
    // and they are initially empty because the Autosuggest is closed.
    this.state = {
      value: '',
      suggestions: []
    };
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

  render() {
    const { value, suggestions } = this.state;

    // Autosuggest will pass through all these props to the input.
    const inputProps = {
      placeholder: 'Enter a username',
      value,
      onChange: this.onChange
    };

    // Finally, render it!
    return (
      <Autosuggest
        suggestions={suggestions}
        onSuggestionsFetchRequested={this.onSuggestionsFetchRequested}
        onSuggestionsClearRequested={this.onSuggestionsClearRequested}
        getSuggestionValue={getSuggestionValue}
        renderSuggestion={renderSuggestion}
        inputProps={inputProps}
      />
    );
  }
}

function EnterSideLeagueData() {
  return(
    <div>
      Enter Side League Data
    </div>
  )
}