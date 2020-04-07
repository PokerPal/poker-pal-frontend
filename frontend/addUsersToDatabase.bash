curl -X POST "http://localhost:5000/users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"email\":\"ja853@bath.ac.uk\",\"name\":\"James Austen\",\"password\":\"james\"}"
curl -X POST "http://localhost:5000/users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"email\":\"lsg38@bath.ac.uk\",\"name\":\"Lucy Green\",\"password\":\"lucy\"}"
curl -X POST "http://localhost:5000/users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"email\":\"jm2787@bath.ac.uk\",\"name\":\"Jake Mifsud\",\"password\":\"jake\"}"
curl -X POST "http://localhost:5000/users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"email\":\"snm48@bath.ac.uk\",\"name\":\"Soren Mortensen\",\"password\":\"soren\"}"
curl -X POST "http://localhost:5000/users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"email\":\"oof26@bath.ac.uk\",\"name\":\"Oisin OFlaherty\",\"password\":\"oisin\"}"
curl -X POST "http://localhost:5000/users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"email\":\"sr2058@bath.ac.uk\",\"name\":\"Sam Rosenthal\",\"password\":\"sam\"}"
curl -X POST "http://localhost:5000/users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"email\":\"gjcr20@bath.ac.uk\",\"name\":\"Geordie Ross\",\"password\":\"geordie\"}"
curl -X POST "http://localhost:5000/leagues" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"name\":\"Main League\",\"allowChanges\":false,\"type\":\"Points\"}"
curl -X POST "http://localhost:5000/leagues" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"name\":\"Side League\",\"startingAmount\":10000,\"allowChanges\":true,\"type\":\"Cash\"}"
curl -X POST "http://localhost:5000/sessions" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"startDate\":\"2020-04-07T17:42:23.159Z\",\"endDate\":\"2020-04-07T17:42:23.159Z\",\"leagueId\":1}"
curl -X POST "http://localhost:5000/sessions" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"startDate\":\"2020-05-07T17:42:23.159Z\",\"endDate\":\"2020-05-07T17:42:23.159Z\",\"leagueId\":1}"
curl -X POST "http://localhost:5000/sessions" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"startDate\":\"2020-06-07T17:42:23.159Z\",\"endDate\":\"2020-06-07T17:42:23.159Z\",\"leagueId\":1}"
curl -X POST "http://localhost:5000/sessions" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"startDate\":\"2020-04-07T17:42:23.159Z\",\"endDate\":\"2020-04-07T17:42:23.159Z\",\"leagueId\":2}"
curl -X POST "http://localhost:5000/sessions" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"startDate\":\"2020-05-07T17:42:23.159Z\",\"endDate\":\"2020-05-07T17:42:23.159Z\",\"leagueId\":2}"
curl -X POST "http://localhost:5000/sessions" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"startDate\":\"2020-06-07T17:42:23.159Z\",\"endDate\":\"2020-06-07T17:42:23.159Z\",\"leagueId\":2}"
curl -X POST "http://localhost:5000/sessions/1" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":1,\"totalScore\":10}"
curl -X POST "http://localhost:5000/sessions/1" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":2,\"totalScore\":11}"
curl -X POST "http://localhost:5000/sessions/1" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":3,\"totalScore\":12}"
curl -X POST "http://localhost:5000/sessions/1" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":4,\"totalScore\":13}"
curl -X POST "http://localhost:5000/sessions/1" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":5,\"totalScore\":14}"
curl -X POST "http://localhost:5000/sessions/1" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":6,\"totalScore\":15}"
curl -X POST "http://localhost:5000/sessions/1" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":7,\"totalScore\":16}"
curl -X POST "http://localhost:5000/sessions/1/finalize" -H "accept: text/plain"
curl -X POST "http://localhost:5000/sessions/2" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":1,\"totalScore\":10}"
curl -X POST "http://localhost:5000/sessions/2" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":2,\"totalScore\":11}"
curl -X POST "http://localhost:5000/sessions/2" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":3,\"totalScore\":12}"
curl -X POST "http://localhost:5000/sessions/2" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":4,\"totalScore\":13}"
curl -X POST "http://localhost:5000/sessions/2" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":5,\"totalScore\":14}"
curl -X POST "http://localhost:5000/sessions/2" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":6,\"totalScore\":15}"
curl -X POST "http://localhost:5000/sessions/2" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":7,\"totalScore\":16}"
curl -X POST "http://localhost:5000/sessions/2/finalize" -H "accept: text/plain"
curl -X POST "http://localhost:5000/sessions/3" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":1,\"totalScore\":10}"
curl -X POST "http://localhost:5000/sessions/3" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":2,\"totalScore\":11}"
curl -X POST "http://localhost:5000/sessions/3" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":3,\"totalScore\":12}"
curl -X POST "http://localhost:5000/sessions/3" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":4,\"totalScore\":13}"
curl -X POST "http://localhost:5000/sessions/3" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":5,\"totalScore\":14}"
curl -X POST "http://localhost:5000/sessions/3" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":6,\"totalScore\":15}"
curl -X POST "http://localhost:5000/sessions/3" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":7,\"totalScore\":16}"
curl -X POST "http://localhost:5000/sessions/3/finalize" -H "accept: text/plain"
curl -X POST "http://localhost:5000/sessions/4" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":1,\"totalScore\":100}"
curl -X POST "http://localhost:5000/sessions/4" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":2,\"totalScore\":110}"
curl -X POST "http://localhost:5000/sessions/4" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":3,\"totalScore\":120}"
curl -X POST "http://localhost:5000/sessions/4" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":4,\"totalScore\":130}"
curl -X POST "http://localhost:5000/sessions/4" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":5,\"totalScore\":140}"
curl -X POST "http://localhost:5000/sessions/4" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":6,\"totalScore\":150}"
curl -X POST "http://localhost:5000/sessions/4" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":7,\"totalScore\":160}"
curl -X POST "http://localhost:5000/sessions/4/finalize" -H "accept: text/plain"
curl -X POST "http://localhost:5000/sessions/5" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":1,\"totalScore\":100}"
curl -X POST "http://localhost:5000/sessions/5" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":2,\"totalScore\":110}"
curl -X POST "http://localhost:5000/sessions/5" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":3,\"totalScore\":120}"
curl -X POST "http://localhost:5000/sessions/5" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":4,\"totalScore\":130}"
curl -X POST "http://localhost:5000/sessions/5" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":5,\"totalScore\":140}"
curl -X POST "http://localhost:5000/sessions/5" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":6,\"totalScore\":150}"
curl -X POST "http://localhost:5000/sessions/5" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":7,\"totalScore\":160}"
curl -X POST "http://localhost:5000/sessions/5/finalize" -H "accept: text/plain"
curl -X POST "http://localhost:5000/sessions/6" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":1,\"totalScore\":100}"
curl -X POST "http://localhost:5000/sessions/6" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":2,\"totalScore\":110}"
curl -X POST "http://localhost:5000/sessions/6" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":3,\"totalScore\":120}"
curl -X POST "http://localhost:5000/sessions/6" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":4,\"totalScore\":130}"
curl -X POST "http://localhost:5000/sessions/6" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":5,\"totalScore\":140}"
curl -X POST "http://localhost:5000/sessions/6" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":6,\"totalScore\":150}"
curl -X POST "http://localhost:5000/sessions/6" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userID\":7,\"totalScore\":160}"
curl -X POST "http://localhost:5000/sessions/6/finalize" -H "accept: text/plain"