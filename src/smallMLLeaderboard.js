import React, { useMemo, useState, useEffect } from "react"
import axios from 'axios'
import Cookies from 'universal-cookie';

import Table from './Table'

import './Tournaments.css'

export function  SmallMLLeaderboard(){
  const cookies = new Cookies();
  const userID = cookies.get('userID')
  const [data, setData] = useState([]);

  useEffect(() => {
    (async () => {
      // const result = await axios("http://localhost:5000/leagues/1/user/"+userID+"/?context=2");
      const result = await axios(process.env.REACT_APP_BACKEND_URL+"leagues/1/user/"+userID+"/?context=2");
      // console.log(result.data.value)
      setData(result.data.value);
    })();
  } ); // , [] // REMOVED AS UNUSED

  const columns = useMemo(
    () => [
      {
        Header: "Nearest Competitors",
        columns: [
          {
            Header: "User Name",
            accessor: "userName"
          },
          {
            Header: "Points",
            accessor: "totalScore"
          }
        ]
      }
    ],
    []
  );

  return (
    <div>
      <Table columns={columns} data={data} />
    </div>
  );
}

export default SmallMLLeaderboard