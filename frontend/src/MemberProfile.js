import profilePicture from "./profilePicPlaceholder.jpg"
import React from "react";
import Cookies from 'universal-cookie';

export function MemberProfile() {
    return (
        <div className="App">
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
                        {/*<p>rank = </p>*/}
                        <GetRank/>
                        <p>balance = </p>
                        <p>wins = </p>
                    </div>

                </div>
            </div>

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

// TODO - REPLICATE FOR GetBalance, GetNumWins
function GetRank(){
    const cookies = new Cookies();
    console.log(cookies.get('userID')); // TODO - REMOVE WHEN DONE TESTING
    let userID = cookies.get('userID');

    let request = new XMLHttpRequest();
    let filePath = "";
    // TODO - GET CURRENT RANK FROM MAIN LEAGUE
    /*request.open('GET', "http://localhost:5000/"+filePath+"/"+userID, true);*/
    request.open('GET', "http://localhost:5000/"+"user"+"/"+"1", true); // TODO - REPLACE WITH LINE ABOVE
    request.onload = function(){
        let data = JSON.parse(this.response);
        let rank = 1;
        if (data.error == null) {
            console.log(data);
            let rank = 1; // TODO - SET AS DATA.RANK WHEN BACKEND COMPLETED
            /*const cookies = new Cookies();*/ // TODO - DECIDE IF COOKIES HAVE TO BE SET HERE
            /*cookies.set('userName', data.value.name, { path: '/' });
            cookies.set('userID', data.value.id, { path: '/' });*/
            /*return (
              <div className="smaller-text">
                  <p>rank = {rank}</p>
              </div>
            )*/
        }
        return (
          <div className="smaller-text">
              <p>rank = {rank}</p>
          </div>
        )
    };
    request.send();

    return ( // this is currently getting returned, not ideal. TODO - sort. Could be that a cookie is set then read immediately
      <div className="smaller-text">
          <p>rank = {"1"}</p>
      </div>
    )
}

function GetBalance(){

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

function GetNumWins(){

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