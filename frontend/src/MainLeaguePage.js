import React from "react";
import './Tournaments.css';
import MainLeagueLeaderboard from './MainLeagueLeaderboard'
import MainLeagueGraph from './MainLeagueGraph.js'
import Cookies from 'universal-cookie';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import axios from 'axios'

export function MainLeaguePage() {
    const cookies = new Cookies();
    //var userID  = cookies.get('userID'); 
    const userID = 1;
    var userName = cookies.get('userName');
    var lastUpdate = "11/10/20"    
    return (
        <div className="Tournament">
            <body>
                <div>
                    <div className="tournamentLeftSection">
                        <p><strong>Current Points</strong></p>
                        <CurrPlace/>
                        <p><strong>Win Streak</strong></p>
                        <WinStreak/>
                        <p><strong>Last Updated</strong></p>
                        <LastUpdated/>
                        <p>
                            <button className="session-button" >
                                <a href="/adminOptions" className="tournamentLink">Add Session Data</a>
                            </button>
                        </p>
                    </div>
                    <div className="tournamentRightSection">
                            <p><strong>Place History </strong></p>
                            <MainLeagueGraph/>
                            <p>
                            <strong>Leaderboard </strong></p>
                            <MainLeagueLeaderboard/>
                    </div>
                </div>
            </body>
        </div>
    );
}

class CurrPlace extends React.Component{
    constructor(props){
        super(props);
        var cookies = new Cookies();
        this.state = {
            currPlace: "User has not joined any sessions",
            userID: cookies.get('userID')
        }
    }
    async componentDidMount(){
        axios.get('http://localhost:5000/leagues/1/user/'+this.state.userID)
          .then((response) => {
            this.setState({currPlace: response.data.value.totalScore});
          }, (error) => {
            console.log(error);
          });
        
    }
    render(){
        return(
            <p>
                {this.state.currPlace}
            </p>
        );
    }
}
class LastUpdated extends React.Component{
    constructor(props){
        super(props);
        var cookies = new Cookies();
        this.state = {
            lastUpdate: "User has not joined any sessions",
            userID: cookies.get('userID')
        }
    }
    
    async componentDidMount(){
        this.setState({currPlace:2})
        axios.get('http://localhost:5000/users/'+this.state.userID+'/sessions/')
          .then((response) => {
              var sessions = response.data.value
              var recentSession = new Date(response.data.value[response.data.value.length-1].startDate)
              this.setState({lastUpdate: recentSession.toDateString()});
          }, (error) => {
            console.log(error);
          });
        
    }
    render(){
        return(
            <p>
                {this.state.lastUpdate}
            </p>
        );
    }
}
class WinStreak extends React.Component{constructor(props){
    super(props);
    var cookies = new Cookies();
    this.state = {
        streak: 0,
        WL: "user is not on a streak",
        userID: cookies.get('userID')
    }
}

async componentDidMount(){
    this.setState({currPlace:2})
    axios.get('http://localhost:5000/users/'+this.state.userID+'/streak/1')
      .then((response) => {
          this.setState({
              streak: response.data.value.streak,
              WL: response.data.value.streakType
            });
      }, (error) => {
        console.log(error);
      });
    
}
render(){
    return(
        <p>
            {this.state.streak + " " + this.state.WL}
        </p>
    );
}
}