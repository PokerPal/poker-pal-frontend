import React from "react";

export function MainLeaguePage() {
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
        <div className="App">
            <body>
                <div className="section">
                    <div className="leftSection">
                        <p>Current Place</p>
                        <input style={textBoxStyle} placeholder="10"></input>
                        <p>Highest Place</p>
                        <input style={textBoxStyle} placeholder="1"></input>
                        <p>Last Updated</p>
                        <input style={textBoxStyle} placeholder="10/12/20"></input>
                    </div>
                    <div className="rightSection">
                            <p style={pStyle}>Place History</p>
                            <svg width={pWidth} height={pHeight}>
                                <rect width={pWidth}height={pHeight}/>
                            </svg>                                             
                    </div>
                </div>
            </body>
        </div>
    );
}