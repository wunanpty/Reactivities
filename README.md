# Reactivities
A web application focus on social activities. User can register/login/logout. User can upload photo and create user profile page. User can post an activity. User can attend other's activities. User can follow/unfollow other people. User can chat with people.
- Learned from [Udemy Course](https://www.udemy.com/course/complete-guide-to-building-an-app-with-net-core-and-react/): Complete guide to building an app with .Net Core and React
- Deployed to [Azure](https://reactivitiesplus.azurewebsites.net/)
- Deployed to [Linux](http://167.71.116.142/)

## The C#/.NET/React technologies used in this project include:
- Multi-project solution
- Back End: .Net Core
- Front End: React
- CQRS Architecutre + Meidator pattern, MediatR
- Entity Framework Core
- Sqlit, MySql, SQL
- .Net Core Identity, JWT
- Following/Follwoer, Paging/Sorting/Filtering
- Photo Upload
- ASPNET Core SignalR
- Security
- Typescript
- React Router
- Semantic UI
- React Final Form


## Built a Web API in .Net Core with Clean Architecture using the CQRS + Mediator pattern.

CQRS: Command Query Responsibility Segregation pattern. CQRS is more concerned about the flow of our data. 
Commands are going to use our domain and our persistence layer to update our database. 
Query only concerned with retrieving data from the database.
Implementing CQRS in your application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.

Mediator pattern is used to reduce communication complexity between multiple objects or classes. This pattern provides a mediator class which normally handles all the communications between different classes and supports easy maintenance of the code by loose coupling.  With the mediator pattern, communication between objects is encapsulated within a mediator object. Objects no longer communicate directly with each other, but instead communicate through the mediator. This reduces the dependencies between communicating objects, thereby reducing coupling.
A good example to demonstrates mediator pattern is, the control tower at an airport. The pilots of the planes approaching or departing the terminal area communicate with the tower rather than explicitly communicating with one another. The constraints on who can take off or land are enforced by the tower. 
Here in my project, the communication between our API (which is controller) and our application (handler), is a many-to-many relationship. MediatR library is an open source implementation of mediator pattern for .NET applications. We got decoupled requests and handlers that controlled by the mediator. Also, we got thin controller and approach to use CQRS principle.

### Used AutoMapper and MediatR in the .Net projects. 
### Used Entity Framework Core as the Object Relational Mapper. 
### Switched DB provider for Entity Framwork between Sqlite, MySql and SQL.

## Why use Entity Framework Core?
When you develop a new application, your data model changes frequently, and each time the model changes, it gets out of sync with the database. You started these tutorials by configuring the Entity Framework to create the database if it doesn't exist. Then each time you change the data model -- add, remove, or change entity classes or change your DbContext class -- you can delete the database and EF creates a new one that matches the model, and seeds it with test data. 
Another reason why use Entity Framework. Entity Framework core can access many different databases through plug-in libraries called database providers. 
(detail: define connection string for mysql in appsettings.json. in Startup.cs separate Development mode using sqlite, Production mode using mysql or sql)

## Why use aysn method when query DB?
Because they have potential to be long running queries is to always make them asynchronous it's a very very very minimal performance hit to do so and this also makes our application instantly more scalable because when we make a request to our database and we make the method an async method then this is going to pass the database query to a different thread and it's not going to block the threads where they get request is coming in on.

## Why use AutoMapper?
Because our DTOs: data transfer object. allow us to shape the type of data that we are returning because our activities are going to have users as attendees, we do not want to send back the full User object. Instead we want to shape the data in a different way and to help us map our properties from our entities to our DTOs.
AutoMapper: help us take away some of the tedious mapping code we would need to write to map of properties in our entities to our DTOs. Any properties that it finds in both objects that have the same name is automatically going to map them for us.

•	Implemented token-based registration/login/logout using .Net Core Identity

## Why use ASP.NET Core Identiy?
It is a membership system, supports login stored in Identity, supports external providers, comes with default user stores, has UserManager and SignInManager

## What is JWT?
JSON web token. It made up of three parts: header, payloads and signature.
The token is sent back to the client in the form of just a long string separated by three periods. This token is passed to the client. Then when the client wants to access a resource on the server it sends this token every time.
Keep the token as small as possible because it's going to go along with your request to the API.
Signature component the third part of this token, this is what our server uses to verify that this token is valid and hasn't been modified or manipulated in any way. Tokens are signed with a secret key that we stored on the server and we never send to the client, so in order to verify it this token is valid then all our server has to do is to check the secret key that we leave on our server. Compare it to this signature.
