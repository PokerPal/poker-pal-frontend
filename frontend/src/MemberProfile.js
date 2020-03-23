import logo from "./bluffBathLogo.png";
import profilePicture from "./profilePicPlaceholder.jpg"
import React from "react";

export function MemberProfile() {
    return (
        <div className="App">
            <body>

            <div className="side-custom-header">
                <b>Profile</b>
            </div>

            <div className="section">
                <div className="leftSection">
                    <div className="sub-section-header">
                        <b>(Member Name)</b>
                    </div>

                    <img src={profilePicture} className="profile-picture" alt="profilePicture" align="left" width="175" height="175" />

                    <div className="sub-section-header">
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <b>Badges</b>
                    </div>

                    <div className="circle">
                    </div>
                    <div className="circle">
                    </div>
                    <div className="circle">
                    </div>
                    <div className="circle">
                    </div>
                </div>

                <div className="rightSection">
                    <div className="sub-section-header">
                        <b>My Stats</b>
                    </div>
                    <div className="smaller-text">
                        <p>rank = </p>
                        <p>balance = </p>
                        <p>wins = </p>
                    </div>

                </div>
            </div>
            </body>
        </div>
    );
}