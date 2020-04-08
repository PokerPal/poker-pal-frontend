import React from "react";
import Cookies from "universal-cookie";
import {Line} from "react-chartjs-2";
import LargeMLLeaderboard from "./largeMLLeaderboard";

export function Dashboard() {
  const cookies = new Cookies();
  cookies.set('id', '1234', { path: '/' });
  let userID  = cookies.get('id'); // Pacman
  let mlPlace = 10; //NEED TO GET FROM API
  let slBalance = 300000; //NEED TO GET FROM API
  let lastUpdate = "11/10/20";

  return (
    <div className="Tournament">
      <div className="dashboard-header">
        <b>Welcome</b>
      </div>
      <body>
        <div>
          <div className="tournamentLeftSection">
            <br/> <br/>
            <p><strong>Current Main League Place</strong></p>
            <p>{mlPlace}</p>
            <p><strong>Current Side League Balance</strong></p>
            <p>{slBalance}</p>
            <p><strong>Last Updated</strong></p>
            <p>{lastUpdate}</p>
          </div>
          <div className="tournamentRightSection">
            <LargeMLLeaderboard/>
          </div>
        </div>
      </body>
    </div>
  );
}