import React from "react";
import axios from 'axios'
import Cookies from "universal-cookie";
import LargeMLLeaderboard from "./largeMLLeaderboard";

export function Dashboard() {
  const cookies = new Cookies();
  cookies.set('id', '1234', { path: '/' });
  // let userID  = cookies.get('id'); // REMOVED AS UNUSED
  // let mlPlace = 10; //NEED TO GET FROM API // REMOVED AS UNUSED
  // let slBalance = 300000; //NEED TO GET FROM API // REMOVED AS UNUSED
  // let lastUpdate = "11/10/20"; // REMOVED AS UNUSED

  return (
    <div className="Tournament">
      <div className="dashboard-header">
        <b>Welcome</b>
      </div>
        <div>
          <div className="tournamentLeftSection">
            <br/> <br/>
            <p><strong>Current Main League Points</strong></p>
            <CurrPlace/>
            <p><strong>Current Side League Balance</strong></p>
            <BalanceValues/>
            <p><strong>Last Updated</strong></p>
            <LastUpdated/>
          </div>
          <div className="tournamentRightSection">
            <LargeMLLeaderboard/>
          </div>
        </div>
    </div>
  );
}
class BalanceValues extends React.Component{
  constructor(props){
      super(props);
      let cookies = new Cookies();
      this.state = {
          currBal: "User has not joined any sessions",
          userID: cookies.get('userID')
      }
  }
  
  async componentDidMount(){
      this.setState({currPlace:2})
      // axios.get('http://localhost:5000/leagues/2/user/'+this.state.userID+'/history')
      axios.get(process.env.REACT_APP_BACKEND_URL+'leagues/2/user/'+this.state.userID+'/history')
        .then((response) => {
            let sessions = response.data.value
            let currBalance = response.data.value[sessions.length-1].totalScore
            this.setState({
                currBal: currBalance
              });
        })
        .catch(error => {
          console.log(error);
          this.setState({
            currBal: "User has not joined any sessions"
          });
        })

  }
  render(){
      return(
          <div>
              <p>
                  {this.state.currBal}
              </p>
          </div>
         
      );
      }
}
class CurrPlace extends React.Component{
  constructor(props){
      super(props);
      let cookies = new Cookies();
      this.state = {
          currPlace: "User has not joined any sessions",
          userID: cookies.get('userID')
      }
  }

  async componentDidMount(){
      // axios.get('http://localhost:5000/leagues/1/user/'+this.state.userID)
      axios.get(process.env.REACT_APP_BACKEND_URL + 'leagues/1/user/' + this.state.userID)
        .then((response) => {
          if (response.status === 404) {
            console.log("404")
          } else {
            this.setState({currPlace: response.data.value[0].totalScore});
          }
        })
        .catch(error => {
          console.log("CAUGHT")
          console.log(error.response);
          this.setState({
            currPlace: "User has not joined any sessions"
          });
          console.log("AFTER")
        })
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
      let cookies = new Cookies();
      this.state = {
          lastUpdate: "User has not joined any sessions",
          userID: cookies.get('userID')
      }
  }
  
  async componentDidMount(){
    // TODO https://stackoverflow.com/questions/44375477/error-handling-with-axios-requests-in-reactjs?rq=1
      this.setState({currPlace:2})
      // axios.get('http://localhost:5000/users/'+this.state.userID+'/sessions/')
      axios.get(process.env.REACT_APP_BACKEND_URL + 'users/' + this.state.userID + '/sessions/')
        .then((response) => {
          if (response.status === 400) {
            console.log("400")
          }
          // let sessions = response.data.value // REMOVED AS UNUSED
          let recentSession = new Date(response.data.value[response.data.value.length - 1].startDate)
          this.setState({lastUpdate: recentSession.toDateString()});
        })
        .catch(error => {
          console.log(error);
          this.setState({
            lastUpdate: "User has not joined any sessions"
          });
        })
  }
  render(){
      return(
          <p>
              {this.state.lastUpdate}
          </p>
      );
  }
}