import React from "react";
import './Tournaments.css';
import SideLeagueLeaderboard from './SideLeagueLeaderboard'
import SideLeagueGraph from './SideLeagueGraph.js'
import Cookies from 'universal-cookie';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import axios from 'axios'

export function SideLeaguePage() {
    const cookies = new Cookies();
    //var userID  = cookies.get('userID'); 
    const userID = 1;
    var userName = cookies.get('userName');
    var hPlace = 10 //NEED TO GET FROM API
    var lastUpdate = "11/10/20"    
    return (
        <div className="Tournament">
            <body>
                <div>
                    <div className="tournamentLeftSection">
                        <p><strong>Current Place</strong></p>
                        <CurrPlace/>
                        <BalanceValues/>
                        <p><strong>Last Updated</strong></p>
                        <LastUpdated/>
                        <p>
                            <button className="session-button" >
                                <a href="/adminOptions/enterSideLeague" className="tournamentLink">Add Session Data</a>
                            </button>
                        </p>
                    </div>
                    <div className="tournamentRightSection">
                            <p><strong>Balance History </strong></p>
                            <SideLeagueGraph/>
                            <p>
                            <strong>Leaderboard </strong></p>
                            <SideLeagueLeaderboard/>
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
            currPlace: -1,
            userID: cookies.get('userID')
        }
    }
    
    async componentDidMount(){
        axios.get('http://localhost:5000/leagues/2/user/'+this.state.userID)
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
            lastUpdate: -1,
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
class BalanceValues extends React.Component{
    constructor(props){
        super(props);
        var cookies = new Cookies();
        this.state = {
            highBal: -1,
            currBal:-1,
            userID: cookies.get('userID')
        }
    }
    
    async componentDidMount(){
        this.setState({currPlace:2})
        axios.get('http://localhost:5000/leagues/2/user/'+this.state.userID+'/history')
          .then((response) => {
              var sessions = response.data.value
              var currBalance = response.data.value[sessions.length-1].totalScore
              var maxBal = sessions.reduce((max, p) => p.totalScore > max ? p.totalScore : max, sessions[0].totalScore); //Formula I stole online to get max place not sure if/how it works
              this.setState({
                  highBal: maxBal,
                  currBal: currBalance
                });
          }, (error) => {
            console.log(error);
          });
        
    }
    render(){
        return(
            <div>
                <p><strong>Current Balance</strong></p>
                <p>
                    {this.state.currBal}
                </p>
                <p><strong>Highest Balance</strong></p>
                <p>
                    {this.state.highBal}
                </p>
            </div>
           
        );
    }
}