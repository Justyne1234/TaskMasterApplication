# TaskMasterApplication

This is a full-stack Task Master application built using .NET 8 Web API for the backend and Angular 20 for the frontend. The project uses MySQL as the database with Entity Framework Core (EF Core) for database migrations and data access.

Task Master is a task management system that allows users to create, view, edit, and delete tasks associated with their own accounts.


## Tech Stack
- Backend: .NET 8 (ASP.NET Core Web API)
    - PackageReference Include="Google.Apis.Auth" Version="1.75.0"
    - PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.28"
    - PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.28"
    - PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.28"
    - PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="8.0.2"
- Frontend: Angular 20
    - "@angular/material": "^20.2.14",
- Database: MySQL
- ORM: Entity Framework Core (Code First + Migrations)

## Project Structure
- /TaskMaster – .NET Web API project
- /task-master – Angular application
- Database schema is managed using EF Core migrations

## Database
1. Tasks
    - Id (PK)
    - OwnerId (FK)
    - Title
    - Description
    - DueDate
    - Priority
    - Priority
    - Category
    - Status
2. Users
    - Id (PK)
    - Username
    - Password
    - AuthenticationMethod
    - GoogleId

## Application User Flow
1. User is directed to the Login  page
2. User can login using:
    - Username and Password
    - Google Sign-in
3. For users without account:
    - Users can click "Don't have an account yet?", which redirects them to the Registration page where they can create an account using a username and password.
    - Users who log in via Google do not need to register. After a successful login, an account is automatically created by the system, and an authentication token is issued for automatic sign-in. Please note that no password is assigned to these accounts; therefore, users cannot log in using the traditional username and password method.
4. After successful login, the user is redirected to the Dashboard, which contains:
    - A list of the user’s tasks (empty by default)
    - An Add button for creating tasks
    - A Dashboard button to return to the dashboard page
    - A Logout button
5. Users can click on each task to view its details.
6. Users can click the Edit button to modify a task.
    - click Edit Task for submission
7. Users can click the Delete button to permanently remove a task.
8. Users can click the Return button to go back to the dashboard.


## Setup Instructions
## TaskMaster (.NET 8)

1. Configure MySQL connection string in appsettings.json
2. Run migrations: dotnet ef database update
3. Run the API: dotnet run

## task-master (Angular 20)
1. Install dependencies: npm install
2. Start the development server: ng serve

## Google Login
1. Create an OAuth application in the Google Cloud Console. 
    - https://console.cloud.google.com/
2. Obtain the Client ID and Client Secret.
    - APIs and Services
    - Credentials
    - OAth consent screen
    - Download json containing ClientId and Secrets
    - Add email to test users
3. Add the credentials to the application's configuration
    - Backend: appsettings.json
    - frontend: environment.ts

## Features
- Task creation, update, and deletion
- Task listing and management
- RESTful API integration between frontend and backend
- Database persistence using MySQL

Angular runs at: http://localhost:4200
.NET runs at: https://localhost:7143/api/

## Notes
- The project is not using the latest stable versions of .NET and Angular as requested due to local machine limitations.
- Despite version constraints, the core functionality and architecture requirements have been implemented.
- MySQL is used as the relational database, with Entity Framework handling migrations and data modeling.
- A stored procedure implementation was added to the user repository at the request of the assessment team.

## Enhancement
1. Allow users to change their password so that accounts created via Google Sign-In can also log in using the traditional username and password method.

## Author
Task Master Application - developed as part of a technical assessment submission.
