# TaskMasterApplication

This is a full-stack Task Master application built using .NET 8 Web API for the backend and Angular 20 for the frontend. The project uses MySQL as the database with Entity Framework Core (EF Core) for database migrations and data access.

## Tech Stack
- Backend: .NET 8 (ASP.NET Core Web API)
- Frontend: Angular 20
- Database: MySQL
- ORM: Entity Framework Core (Code First + Migrations)

## Project Structure
- /TaskMaster – .NET Web API project
- /task-master – Angular application
- Database schema is managed using EF Core migrations

## Notes
- The project is not using the latest stable versions of .NET and Angular as requested due to local machine limitations.
- Despite version constraints, the core functionality and architecture requirements have been implemented.
- MySQL is used as the relational database, with EF Core handling migrations and data modeling.


## Setup Instructions
## TaskMaster (.NET 8)

1. Configure MySQL connection string in appsettings.json
2. Run migrations: dotnet ef database update
3. Run the API: dotnet run

## task-master (Angular 20)
1. Install dependencies: npm install
2. Start the development server: ng serve

## Features
- Task creation, update, and deletion
- Task listing and management
- RESTful API integration between frontend and backend
- Database persistence using MySQL

Angular runs at: http://localhost:4200
.NET runs at: https://localhost:7143/api/

## Author
Task Master Application – Developed as part of the assessment submission