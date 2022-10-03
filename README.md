# Martian Robots (.Net)
Martian Robots is a Clean Architecture Solution. It is ASP .NET Core Web API using .NET 6.0 and Entity Framework Core, elaborated about clean architecture, principles, and design considerations. 
This API manage the surface of Mars, that It can be modelled by a rectangular grid around which robots are able to move according to instructions provided from Earth. The solution determines each sequence of robot positions and reports the final
position of the robot.

## Technologies
* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [FluentAssertions](https://fluentassertions.com/)

## Getting Started
The easiest way to get started is download solution.
1. Install the latest [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
2. Install the latest DOTNET & EF CLI Tools by using this command `dotnet tool install --global dotnet-ef` 
3. Install the latest version of Visual Studio IDE 2019 (v16.8 and above) 
4. Run in Visual Studio.
 
### Database Configuration

Solution is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).
If the in-memory database usage is active it is seed some data.

If you would like to use SQL Server, you will need to update **WebApi\appsettings.Development.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.Development.json** points to a valid SQL Server instance.

### Create Database(SQL Server)

Ensure that "UseInMemoryDatabase" is disabled, as described within previous section.

Then, in package manager console:
* Make sure, we have selected the **Infrastructure** project as default and **Web API** as startup project.
* Then, we will run the database update command: `Update-Database`
* When finish, The database is created as expected.

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebApi

This layer is a Web API using ASP.NET Core 6.0 with swagger. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. 

## How to use it.
Run it in visual studio. There several ways to usage:
1. Postman.
2. Swagger(Only Get methods)
3. Web browser.

### 1. Postman
Copy next curls and import to your postman app (Ensure to change portnumber):
- Create input:
```json
  curl --location --request POST 'https://localhost:7232/api/Input' \
--header 'Content-Type: text/plain' \
--data-raw '5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFRFLFL'
```

- Get lost robots:
```json
curl --location --request GET 'https://localhost:7232/api/Robot/GetLostRobots'
```

- Explored surface:
```json
curl --location --request GET 'https://localhost:7232/api/ExploredSurface'
```
### 2. Swagger

En Robot y ExploredSurface clicando en "try it out" and then "execute".

### 3. Web browser
Writing https://localhost:7232/api/Robot/GetLostRobots or https://localhost:7232/api/ExploredSurface on the web. Ensure to change portnumber.