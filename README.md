# SurveyApp

## Table of contents
- [SurveyApp](#surveyapp)
  * [Project description](#project-description)
  * [Tech Stack](#tech-stack)
  * [Endpoints](#endpoints)
  * [Database Setup](#database-setup)

## Project description

Practical project for CSCB024

<br/>

## Tech Stack

### Backend:

ASP.NET Core 3.1 Web API

### Frontend:

React 16.0.0

### Database:

MySQL Server 8.0.22

Diagram:
<img src="https://raw.githubusercontent.com/malaclypse/SurveyApp/main/docs/sql_diagram.png">
<br/>

## Endpoints

| Controller          | URL                               | Method | Body type           | Result type            | Description                                                         | Status      |
|---------------------|-----------------------------------|--------|---------------------|------------------------|---------------------------------------------------------------------|-------------|
| UserController      | user/{email}                      | GET    | -                   | User                   | Get a user by email                                                 | DONE        |
| UserController      | user                              | POST   | CreateUserRequest   | User                   | Create new user record                                              | DONE        |
| UserController      | user/{email}                      | PUT    | UpdateUserRequest   | User                   | Update an existing user record                                      | DONE        |
| TextEntryController | textEntry                         | GET    | -                   | IEnumerable<TextEntry> | Gets a list of all texts                                            | DONE (Samuela) |
| CategoryController  | category                          | GET    | -                   | IEnumerable<Category>  | Gets a list of all categories                                       | DONE (Tsveti) |
| SurveyController    | user/{email}/survey               | POST   | CreateSurveyRequest | Survey                 | Create new survey record                                            | DONE (Samuela) |
| SurveyController    | user/{email}/survey               | GET    | -                   | IEnumerable<Survey>    | Get specific survey by id                                           | DONE (Samuela) |
| SurveyController    | user/{email}/survey/{id}          | GET    | -                   | Survey                 | Get specific survey by id                                           | DONE (Tsveti)|
| SurveyController    | user/{email}/survey/{id}          | PUT    | UpdateSurveyRequest | Survey                 | Updates the survey record, for example when the survey is submitted | DONE (Tsveti) |
| MappingController   | user/{email}/survey/{id}/map      | GET    | -                   | IEnumerable<Mapping>   | Get all category-text mappings for a survey                         | DONE (kterziev) |
| MappingController   | user/{email}/survey/{id}/map/{id} | GET    | -                   | Mapping                | Get a category-text mapping by id                                   | DONE (kterziev) |
| MappingController   | user/{email}/survey/{id}/map/{id} | DELETE | -                   | -                      | Delete a category-text mapping                                      | DONE (kterziev) |
 | MappingController   | user/{email}/survey/{id}/map     | POST   | CreateMappingRequest| -                | Create a category-text mapping                                | DONE (kterziev) |

<br/>
The Postman collection with the first three working endpoints can be found here: [Postman](/docs/Survey API.postman_collection.json)
<br/>

## Database Setup

1. Install MySQL Server version 8.0.22
2. Install MySQL Workbench version 8.0.22
3. Open MySQL Workbench and select to rescan for local MySQL instances
   - The installed MySQL instance should be listed
4. Open the SurveyApp.sln solution in Visual Studio
5. In the SurveyApp.Web, find the appsettings.json
6. Replace the user, pass, and port according to your current MySQL instance setup
7. Still in Visual Studio, open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)
8. Run
   > Update-Database -Project SurveyApp.Data
If you refresh the db in MySql Workbench, you should see the newly created surveydatabase
<br/>

If you want to run the Web project, right-click on it and select "Set as startup project).

Ctrl + F5 to start it without debugging, F5 starts debugging.
<br/>
<br/>

### Enums in the database (Entity Framework Core does not support enums as tables directly, so they are saved as ints in the db)

#### Gender
- 0 = Male
- 1 = Female
- 2 = NotSpecified

#### EnglishLevel
- 0 = NoProficiency
- 1 = ElementaryProficiency
- 2 = LimitedWorkingProficiency
- 3 = ProfessionalProficiency
- 4 = FullProfessionalProficiency
- 5 = NativeOrBilingualProficiency

