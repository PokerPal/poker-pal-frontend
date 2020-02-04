default: build

# Build rules

build: backend

backend:
	dotnet build backend/PokerPal.sln

# Run rules

inmemory: backend
	dotnet run -p backend/Api/Api.csproj --launch-profile "Local API/In Memory Database"

postgres: backend
	dotnet run -p backend/Api/Api.csproj --launch-profile "Local API/Postgres"

.PHONY: backend inmemory postgres

