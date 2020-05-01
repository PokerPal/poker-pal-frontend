import React, { useMemo, useState, useEffect } from "react"
import axios from 'axios'

import './Tournaments.css'

import Table from './Table'

export function  LargeMLLeaderboard(){
  const [data, setData] = useState([]);

  useEffect(() => {
    (async () => {
      const result = await axios(process.env.REACT_APP_BACKEND_URL+"leagues/1/users");
      // Table is only rendered if information returned from DB is not null
      if (result.data.value != null) {
        setData(result.data.value);
      }
    })();
  }, []);

  const columns = useMemo(
    () => [
      {
        Header: "Main League",
        columns: [
          {
            Header: "User Name",
            accessor: "userName"
          },
          {
            Header: "PLargeMLLeaderboardoints",
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