default: build

# Build rules

build: backend

backend:
	dotnet build backend/PokerPal.sln

clean:
	dotnet clean backend/PokerPal.sln

# Run rules

inmemory: backend
	dotnet run -p backend/Api/Api.csproj --launch-profile "Local API/In Memory Database"

postgresql: backend
	dotnet run -p backend/Api/Api.csproj --launch-profile "Local API/PostgreSQL"

.PHONY: backend inmemory postgresql

