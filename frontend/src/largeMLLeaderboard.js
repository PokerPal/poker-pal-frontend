import React, { useMemo, useState, useEffect } from "react"
import './Tournaments.css'
import axios from 'axios'
import Table from './Table'
export function  LargeMLLeaderboard(){
    // data state to store the TV Maze API data. Its initial value is an empty array
  const [data, setData] = useState([]);

  // Using useEffect to call the API once mounted and set the data
  useEffect(() => {
    (async () => {
      const result = await axios("http://localhost:5000/leagues/1/users");
      setData(result.data.value);
    })();
  }, []);
  console.log(data);
  /* 
    - Columns is a simple array right now, but it will contain some logic later on. It is recommended by react-table to Memoize the columns data
    - Here in this example, we have grouped our columns into two headers. react-table is flexible enough to create grouped table headers
  */
  const columns = useMemo(
    () => [
      {
        // first group - TV Show
        // First group columns
        Header: "Main League",
        columns: [
          {
            Header: "User ID",
            accessor: "userId"
          },
          {
            Header: "League",
            accessor: "leagueId"
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

export default LargeMLLeaderboard