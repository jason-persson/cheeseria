# cheeseria
The PZ Cheeseria test project

# Development
## Web API and dev server
Open the [Cheeseria.sln](Cheeseria.sln) solution file and run the Server project using the *Debug* configuration. The development server will start up and Swagger documentation
will be available at [http://localhost:5002](http://localhost:5002).

## React front-end
In your terminal go to `src\app` and:
1. To install dependencies, run: `npm install`
1. To start the React development environment, run: `npm start`
1. Browse to: [http://localhost:3000/](http://localhost:3000/)

## Tests
If desired, the unit tests may be run by building the `dotnet_test` target from docker. For example, from the project root run the following in a terminal
- `docker build --target dotnet_test`

# Production
The production system may be built using the `final` target from docker. **Note** only port 80 is exposed i.e. the app does not support HTTPS.
For example, from the project root run the following in a terminal:
1. To build the image: `docker build --target final -t pz_cheeseria .`
1. To run the container: `docker run -dp 80:80 pz_cheeseria`
1. To view the app browse to [http://localhost/](http://localhost/)

# If I had more time
- I would create a domain layer that uses an ICheeseRepository instance.
    - I would unit test the domain layer instead of the InMemoryCheeseRepository class.
- I would use a SQL database. I'm most familiar with SQL Server so I'd use that. If I had even more time I'd use PostgreSQL because I’d like to have a chance to use it.
    - I’d use EF Core to talk to the DB.
    - If warranted I’d use Dapper for complex queries.
- In the React front end if the application logic became more complex I'd consider using Redux along with the Redux Toolkit.


# Image licenses
- "Project 365 #225: 130814 Cheddar Cheese (National Treasure)" by comedy_nose is licensed under CC PDM 1.0.
- "Goat Brie" by larryjh1234 is licensed under CC BY 2.0
- "Danish Blue Cheese" by StuartWebster is licensed under CC BY 2.0
- "File:Typical parmesan cheese.jpg" by thor is licensed under CC BY 2.0
- "Camembert" by grongar is licensed under CC BY 2.0