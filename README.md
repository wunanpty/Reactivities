# Reactivities
A web application focus on social activities. User can register/login/logout. Users can upload a photo and create a user profile page. Users can post an activity. Users can attend to other's activities. Users can follow/unfollow other people. Users can chat with people.
- Learned from [Udemy Course](https://www.udemy.com/course/complete-guide-to-building-an-app-with-net-core-and-react/): Complete guide to building an app with .Net Core and React
- Deployed to [Azure](https://reactivitiesplus.azurewebsites.net/)
- Deployed to [Linux](http://167.71.116.142/)

## The C#/.NET/React technologies used in this project include:
- Multi-project solution
- Back End: .Net Core
- Front End: React
- CQRS Architecutre + Meidator pattern, MediatR
- Entity Framework Core
- SQLite, MySql, SQL
- .Net Core Identity, JWT
- Following/Follower, Paging/Sorting/Filtering
- Photo Upload
- ASPNET Core SignalR
- Security
- Typescript
- React Router
- Semantic UI
- React Final Form


### Built a Web API in .Net Core with Clean Architecture using the CQRS + Mediator pattern.
- CQRS
  - CQRS is Command Query Responsibility Segregation pattern. Implementing CQRS in your application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.
  - CQRS is more concerned about the flow of our data. 
  - Commands are going to use our domain and our persistence layer to update our database. 
  - Query only concerned with retrieving data from the database.

- Mediator
  - Mediator pattern is used to reduce communication complexity between multiple objects or classes. This pattern provides a mediator class which normally handles all the communications between different classes and supports easy maintenance of the code by loose coupling.  With the mediator pattern, communication between objects is encapsulated within a mediator object. Objects no longer communicate directly with each other, but instead communicate through the mediator. This reduces the dependencies between communicating objects, thereby reducing coupling.
  - A good example to demonstrates mediator pattern is, the control tower at an airport. The pilots of the planes approaching or departing the terminal area communicate with the tower rather than explicitly communicating with one another. The constraints on who can take off or land are enforced by the tower. 
  - Here in my project, the communication between our API (which is controller) and our application (handler), is a many-to-many relationship. 
  - MediatR library is an open source implementation of mediator pattern for .NET applications. We got decoupled requests and handlers that controlled by the mediator. Also, we got thin controller and approach to use CQRS principle.

### Why use Entity Framework Core?
- Used Entity Framework Core as the Object Relational Mapper
- When you develop a new application, your data model changes frequently, and each time the model changes, it gets out of sync with the database. Entity Framework can be configured to create the database if it doesn't exist. Then each time you change the data model -- add, remove, or change entity classes or change your DbContext class. You can delete the database and EF creates a new one that matches the model, and seeds it with test data. 
- Another reason why use Entity Framework. Entity Framework core can access many different databases through plug-in libraries called database providers. 
(detail: define connection string for mysql in appsettings.json. in Startup.cs separate Development mode using sqlite, Production mode using mysql or sql)

### Why use aysn method when query DB?
- Because they have the potential to be long-running, queries are to always make them asynchronous. It's a very minimal performance hit to do so. And this also makes our application instantly more scalable, because when we make a request to our database and we make the method an async method, then this is going to pass the database query to a different thread, and it's not going to block the threads where they get request is coming in on.

### Why use AutoMapper?
- Because of our DTOs: data transfer object.  Allow us to shape the type of data that we are returning because our activities are going to have users as attendees, we do not want to send back the full User object. Instead, we want to shape the data in a different way and to help us map our properties from our entities to our DTOs.
- AutoMapper: help us take away some of the tedious mapping code we would need to write to map properties in our entities to our DTOs. Any properties that it finds in both objects that have the same name are automatically going to map them for us.

### Why use ASP.NET Core Identiy?
- Membership system
- Supports login stored in Identity
- Supports external providers
- Comes with default user stores
- UserManager
- SignInManager

### What is JWT?
- JWT is Json Web Token. It made up of three parts: header, payloads and signature.
- The token is sent back to the client in the form of just a long string separated by three periods. This token is passed to the client. Then when the client wants to access a resource on the server it sends this token every time.
- Keep the token as small as possible because it's going to go along with your request to the API.
- Signature component the third part of this token, this is what our server uses to verify that this token is valid and hasn't been modified or manipulated in any way. Tokens are signed with a secret key that we stored on the server and we never send to the client, so in order to verify it this token is valid then all our server has to do is to check the secret key that we leave on our server. Compare it to this signature.
- The infrastructure project is responsible for the generation of tokens. Anything related to security will run inside the infrastructure project.
- A [JWT decoder](https://jwt.io/#debugger-io)
- Authentication (who are you?), Authorization (are you allowed?)

### Axios
- Axios is an hugely popular (over 52k stars on Github) HTTP client that allows us to make GET and POST requests from the browser. Therefore, we can use Axios with React to make requests to an API, return data from the API, and then do things with that data in our React app.
- Use [Axios libray](https://github.com/axios/axios) to request http.
- Axios interceptors：For every single request where we have a token, we're going to want to send that along with our request to our API so that we can authenticate to our API server.

### Semantic UI
- [Semantic UI](https://react.semantic-ui.com/)

### MobX
- State management system. API is pretty small. There are only four methods from MobX: Observable, Action, Computed, and Reaction.
- We are going to be using for our store is the Observer. We are going to get this from a separate package called mobx-react-lite. And this provides a higher-order component and we can use this higher-order component to make our React Components observers of our store and whenever that component is an observer of a store. Any changes to any of the observables are going to be observed our right.

### React Router
- When it comes to reacts there's normally a lot of decisions to be made about which packages you're going to use to help you build your application. What's the assessed framework. What state management solution. What forms library you're going to use. But when it comes to rooting that decision is a lot easier. The community has settled pretty much on just one particular rooting solution and that is the [React Router](https://reactrouter.com/web/api/BrowserRouter), because we're building a web application, we're going to use react router dom.

### Validation and Error handling
- Validation in our API is essential. We want to protect our server from receiving bad data from the client and the way that we can do that is by validating the data that is sent from the client to our server.
We can use [Fluent Validation](https://fluentvalidation.net/) to validate data.
Due to the nature of our application architecture and the fact that we want to use extremely thin API controllers that means our API controllers are going to be dumb, they're not going to be responsible for throwing exceptions or handling validation or anything like that. They're still just going to be that simple dumb API controllers. Our error handling and exception handling logic is going to need to move into our application project. It's our business logic that's going to define whether a request has an error or not on the client-side.
- Validation on the client is nice to have, we should definitely include it. But it is not as important as validating the data on the server. Use [Revalidate](https://github.com/jfairbank/revalidate) and [combineValidators](http://revalidate.jeremyfairbank.com/usage/combineValidators.html)

### Photo Upload
- Photo storage options
  - Database: Inefficient. Stores files as BLOBs. Disk space is an issue. Authentication is easy.
  - File System: Good for storing files. Disk space is an issue. File permissions.
  - Cloud Service: Scalable. Could be more expensive. Secured with API Key.
- Here we use cloud service, we use [Cloudinary](https://cloudinary.com/documentation/dotnet_integration#dotnet_getting_started_guide). Because it does provide us with an API key and an API secrets, and we can make sure our users are authenticated with our API before we allow them to upload the photo to cloudinary.
- And because we use cloud service, then we do not need to worry about disk space. And it is very scalable. And because it is a service that specialized in delivering files over a distributed network, then it is potentially faster than how we can serve them ourselves.
- Client side use [React Dropzone](https://react-dropzone.js.org/) and [React Cropper](https://github.com/react-cropper/react-cropper)


