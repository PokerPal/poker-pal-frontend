import logo from "./bluffBathLogo.png";
import React from "react";
import './Tournaments.css'
import {Line} from 'react-chartjs-2';
import SideLeagueLeaderboard from "./SideLeagueLeaderboard";
import Cookies from 'universal-cookie';
export function SideLeaguePage() {
    const cookies = new Cookies();
    cookies.set('id', '1234', { path: '/' });
    var userID = cookies.get('id'); // Pacman
    var hPlace = 10
    var cPlace = 10
    var lastUpdate = "11/10/20"
    var bHistory = {
        labels: ["January", "February", "March", "April", "May", "June", "July"], //WHAT DO WE WANT ON AXIS?
        datasets: [{
            label : 'Place History',
            backgroundColor: '#0013ae',
            borderColor: '#0013ae',
            data: [0, 10, 5, 2, 20, 30, 45], //NEED TO GET FROM API
        }]
    }
    return (
        <div className="Tournament">
            <body>
                <div>
                    <div className="tournamentLeftSection">
                        <p><strong>Current Balance</strong></p>
                        <p>{cPlace}</p>
                        <p><strong>Highest Balance</strong></p>
                        <p>{hPlace}</p>
                        <p><strong>Last Updated</strong></p>
                        <p>{lastUpdate}</p>
                    </div>
                    <div className="tournamentRightSection">
                            <p><strong>Balance History</strong></p>
                            <Line data={bHistory}/>                                    
                            <p><strong>Leaderboard</strong></p>
                            <SideLeagueLeaderboard/>
                    </div>
                </div>
            </body>
        </div>
    );
}