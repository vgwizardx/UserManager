# UserManager Project


"Create a project in C# with an initial page that shows a list of names with information such as address, phone number, and age. On clicking a name, navigate to a details view where the user can edit the individual's information. Have a Save Cancel and Delete options. Develop the front end using Blazor and architect the solution to show understanding of SOLID principles with the implementation 
of an API, Controllers, Services, and Data Repositories."

# Application Information Page

## UserManager Project UI

To see the project go [here](http://localhost:40417). If you run into problems double check port (default 8081) is open if you can't connect.

## Seq Logs

Seq is a centralized log file with superpowers. It's a tool that takes logs from your application and stores them in an easily searchable and analyzable format. This is incredibly useful for debugging and monitoring your applications. You can view the Seq logs for this application after running the in visual studio 2022 in debug [here](http://localhost:8081). If you run into problems double check port (default 8081) is open if you can't connect.

## Swagger API Documentation

Swagger provides a user-friendly interface to interact with the API's endpoints. It's a tool used for documenting APIs and also provides an easy way to test them. To explore the API documentation and test the endpoints, after running the application in debug visit the [Swagger page here](http://localhost:26375/swagger/index.html) if it doesn't open automatically. Also, double check port (default 26375) is open if you can't connect..

## Connecting to the PostgreSQL Database

This application uses PostgreSQL as its database. To connect to the database, use the following credentials:

- Database: UsermanagerAPP
- Username: UsermanagerAPP
- Password: postgres@123456!

Ensure you have PostgreSQL client tools installed and use these credentials in your connection string.

## Additional notes
I only tested this in debug and so it may not work if you have it set to Release in visual studio 2022. I also only tested it with Visual Studio. So may not work as expected when using Rider or VS Code. Also make sure you have docker-compose as the start project.

## Application Requirements

- Visual Studio 2022 (in debug and docker-compose as the start project)
- .NET 8
- Docker Desktop

## What's inside
- Serilog
- Seq
- Blazor
- BootStrap
- AutoBogus (used to seed the database)
- EF Core Postgres with Migrations
- DockerFile
- DockerCompose
- Some Unit test 
- DDD
- Solid principles 




