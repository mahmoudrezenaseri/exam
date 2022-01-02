## How we'd like to recieve the soluion?

1. Clone this repository and upload it as a new public repository in your github account
2. Create a new branch in your repository
3. Create a pull request with the requested functionality to unchanged master branch in your repository
4. Share link to the PR with us 

# Description
This solution has 2 diferent projects in it.

- API project which is located in root directory
- IntegrationTest project which is in **Test** directory

# Tasks

1. Create an Entity called **User** which contains below properties : 
    
    - FirstName
    - LastName ( It's mandatory)
    - NationalCode (It should be a valid national code)  
    - PhoneNumber  (It should be a valid Phone number)   
2. Connect project to a database (SQLServer, PostgreSQL, ...)
3. Create **UserController** and add two endpoint for :
    
    - **Creating** a user
    - **Update** a user
    - **Get** the information of a user 
4. Add **IntegrationTest** for above endpoints

**Note**: You must apply validation rules related to entity.

### What we are looking for

- Ability to Use git version control
- Create a new or modify existing web API and containerize it by using Docker.(Add Services, Use Middlewares, Routings, Validation)
- Persist and retrieve relational data with Entity Framework Core and/or Dapper
- Add Swagger to ensure you have a way to document your API.
-  How you test the correctness of your solution, and the Integration tests.
