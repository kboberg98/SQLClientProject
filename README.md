# SQLClientProject

## Project Description
SQLClientProject is a C# project that demonstrates how to connect to a SQL Server database using the Microsoft.Data.SqlClient library. The project includes several repositories that demonstrate different SQL queries that can be executed against a sample database.

SuperheroesDb_Scripts folder contains all the scripts to create SuperheroesDb with the tables SuperHero, Assistant, Power and SuperheroPowerLink aswell as creating the relationship between the tables and inserting, updating and deleting values in the tables.

## Getting Started
To run this project, you will need to have .NET Core 3.1 or higher installed on your machine. You will also need to have access to a SQL Server database that contains the sample Chinook database schema. You can download the Chinook database from GitHub and import it into your SQL Server instance.

Once you have the Chinook database set up, you can clone this repository to your local machine and open the solution in Visual Studio or another IDE that supports .NET development. You may need to update the connection string in the ConnectionStringHelper class to point to your SQL Server instance.

## Project Structure
The SQLClientProject solution contains the following projects:

SQLClientProject: The main project that contains the repository interfaces and implementation classes.
SQLClientProject.Models: A class library project that contains the model classes used by the repositories.
The repository interfaces and classes are organized into sub-namespaces based on the type of query being executed. For example, the CustomerGenreRepository class implements the ICustomerGenreRepository interface and executes a query to return a list of customers and their favorite music genres.

## Running the Tests
The SQLClientProject.Program includes tests that test the functionality of the repository classes. Start Debugging/Start Without Debugging to run the tests in Program.cs. Most tests are commented out, uncomment to run the a specific test.
