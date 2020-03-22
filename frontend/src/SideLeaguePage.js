import logo from "./bluffBathLogo.png";
import React from "react";

export function SideLeaguePage() {
    var pWidth=500
    var pHeight=200
    var pStyle = {
        color:'#0013ae'
    }
    var textBoxStyle ={
        readOnly:'true',
        textAlign:'right'
    }
    return (
        <div className="Tournament">
            <body>
                <div>
                    <div className="tournamentLeftSection">
                        <p>Current Place</p>
                        <input style={textBoxStyle} placeholder="10"></input>
                        <p>Highest Place</p>
                        <input style={textBoxStyle} placeholder="1"></input>
                        <p>Last Updated</p>
                        <input style={textBoxStyle} placeholder="10/12/20"></input>
                    </div>
                    <div className="tournamentRightSection">
                            <p>Place History</p>
                            <svg width={pWidth} height={pHeight}>
                                <rect width={pWidth}height={pHeight}/>
                            </svg>                                             
                            <p>Leaderboard</p>
                            <svg width={pWidth} height={pHeight}>
                                <rect width={pWidth}height={pHeight}/>
                            </svg>  
                    </div>
                </div>
            </body>
        </div>
    );
}