import React, { useMemo, useState, useEffect } from "react"
import './Tournaments.css'
import axios from 'axios'
import Table from './Table'
export function  LargeMLLeaderboard(){
  const [data, setData] = useState([]);

  useEffect(() => {
    (async () => {
      const result = await axios("http://localhost:5000/leagues/1/users");
      setData(result.data.value);
    })();
  }, []);

  
  const columns = useMemo(
    () => [
      {
        // first group - TV Show
        // First group columns
        Header: "Main League",
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

export default LargeMLLeaderboard