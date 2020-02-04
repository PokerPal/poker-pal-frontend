# PokerPal

This repository contains code for both the frontend and backend of the PokerPal application.

## Backend

The backend code is contained in `backend/`. The backend is an ASP.NET Core app written in C#.

### Building the Project

#### Prerequisites

First, you'll need to install:

- [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/sdk)
- [`dotnet-ef`](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)

You also might want to install one of:

- [JetBrains Rider](https://www.jetbrains.com/rider/) (recommended)
- [Visual Studio](https://visualstudio.microsoft.com/)

#### Building

You have several options:

- If you have `make` installed (most Unix-based systems will by default), run `make backend` (or 
  `make` to build backend and frontend) from the top level of the repository.
- Run `dotnet build` from inside the `backend/` directory.
- Open the solution in Rider or Visual Studio and run the build action.

#### Running

Again, several options:

- With `make`, run `make inmemory` to run the backend only with an in-memory database; this is what 
  you want for development most of the time.
- With `make`, run `make postgres` to run the backend only with a PostgreSQL database.
- Manually run `dotnet run --launch-profile "Local API/In Memory Database"`
- Manually run `dotnet run --launch-profile "Local API/Postgres"`
- Run one of the two launch profiles from within Rider or Visual Studio

