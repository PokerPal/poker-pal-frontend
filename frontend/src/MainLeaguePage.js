import React from "react";
import './Tournaments.css';
import {Line} from 'react-chartjs-2';
export function MainLeaguePage() {
    var pWidth=500
    var pHeight=200
    var hPlace = 10 //NEED TO GET FROM API
    var cPlace = 10 //NEED TO GET FROM API
    var lastUpdate = "11/10/20"
    var pHistory = {
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
                        <p><strong>Current Place</strong></p>
                        <p>{cPlace}</p>
                        <p><strong>Highest Place</strong></p>
                        <p>{hPlace}</p>
                        <p><strong>Last Updated</strong></p>
                        <p>{lastUpdate}</p>
                    </div>
                    <div className="tournamentRightSection">
                            <p><strong>Place History</strong></p>
                            <Line data={pHistory}/>                                   
                            <p><strong>Leaderboard</strong></p>
                            <svg width={pWidth} height={pHeight}>
                                <rect width={pWidth}height={pHeight}/>
                            </svg>  
                    </div>
                </div>
            </body>
        </div>
    );
}