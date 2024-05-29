# User Management API Clean Architecture

## Versioning
| GitHub Release | .NET Core Version | C#|
|----------------|------------ |---------------------|
| main | 8.0| 12 |


    
## Project Structure
```
├───API
│   ├───Configuration
│   ├───Controllers
│   ├───Middlewares
│   └───Properties
├───Application
│   ├───Authentication
│   ├───Behaviors
│   ├───Commands
│   │   ├───Roles
│   │   │   ├───AddUserToRoles
│   │   │   └───CreateRole
│   │   └───User
│   │       ├───Login
│   │       ├───Register
│   │       └───Update
│   ├───DTOs
│   ├───Exceptions
│   ├───Profiles
│   ├───Queries
│   │   ├───GetUsers
│   │   └───UserProfile
│   ├───Services
│   └───Shared
├───Domain
│   ├───Entities
│   └───Repositories
└───Infrastructure
    ├───Authentication
    ├───Data
    ├───Migrations
    ├───Repositories
    └───Services
```

## Getting Started
Use these instructions to get the project up and running.


### Prerequisites
You will need the following tools:

* [.Net Core 8.0.5 ](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* EF Core 8.0.5 
* [ postgresql-16.3 ](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)


### Installing
Follow these steps

- Clone the repository

```
$ git clone https://github.com/Kitiashvili/UserManagementApi.git
$ cd  UserManagement
```


- At the root directory, restore required packages by running:
```csharp
dotnet restore
```
- Next, build the solution by running:
```csharp
dotnet build
```
- Next, launch the api by running:
```csharp
cd API
dotnet run
```
- Launch http://localhost:5134/index.html in your browser to view the Web UI.



### Database Configuration

- Ensure your connection strings in ```appsettings.json``` point to a local ```postgresql``` Server instance.

- Open a command prompt in the Web folder and execute the following commands:

```csharp
dotnet restore
cd ..
dotnet ef database update --project Infrastructure --startup-project API
```

- Run the application.
The first time you run the application, it will seed  postgresql server database with a ```User``` and ```Role``` for login

```Email : admin@gmail.com```
```Password : admin123```
```Username : admin```



If you modify-change or add new some of entities to Core project, you should run ef migrate commands:
```csharp
dotnet ef migrations add  "initial" --project Infrastructure --startup-project API

dotnet ef database update --project Infrastructure --startup-project API
```

## Deploying a Elasticsearch & Kibana on Docker

### Prerequisite:

- [Docker](https://www.docker.com/get-started/#h_installation)

To run ```Elasticsearch & Kibana``` following these steps:

```sh
$ cd API
```

```sh
$ docker compose up
```
- Launch http://localhost:5601/   Kibana.

- Launch http://localhost:9200/  Elasticsearch.


