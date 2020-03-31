import profilePicture from "./profilePicPlaceholder.jpg"
import React from "react";
import Cookies from 'universal-cookie';

export function MemberProfile() {
    return (
        <div className="App">
            <body>



            <div className="side-custom-header">
                <b>Profile</b>
            </div>

            <div className="section">
                <div className="leftSection">
                    <GetUserName/>
                    {/*<div className="sub-section-header">
                        <b>(Member Name)</b>
                    </div>*/}

                    <img src={profilePicture} className="profile-picture" alt="profilePicture" align="left" width="175" height="175" />

                    <div className="sub-section-header">
                        <br></br>
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

function GetUserName(){
    const cookies = new Cookies();
    /*cookies.set('myCat', 'Pacman', { path: '/' });*/
    console.log(cookies.get('userName'));
    let name = cookies.get('userName');
    return (
      <div className="sub-section-header">
        <b>{name}</b>
      </div>
    )
}