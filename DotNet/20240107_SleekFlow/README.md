# 20240107_SleekFlow
# Sleekflow Software Engineer Project  **Objective:** Develop a scalable and well-designed TODO list API application that allows users to manage their TODOs, demonstrating your backend development skills, API design expertise, and software engineering best practices.


# Info
1) This project is using .net core 7 , so need to install sdk 7 
2) This project's database is using MySQL
3) that is some plug-in needed : 
3.1) Microsoft.EntityFrameworkCore (7.0.15)
3.2) Microsoft.EntityFrameworkCore.SqlServer (7.0.15)
4) 2 API are able to call: 
4.1) API to get all list of Todo
curl --location 'https://localhost:7119/api/todo/getFullList' \
--header 'Content-Type: application/json' \
--data '{
  "statusIDSelected": [
    1,
    2
  ],
  "dueDateFrom": "2024-01-14T14:21:46.857Z",
  "dueDateTo": "2024-01-14T14:21:46.857Z"
}'
4.2) API CRUD for Todo
curl --location 'https://localhost:7119/api/todo/crud' \
--header 'Content-Type: application/json' \
--data '{
  "action": "string", 
  "todoData": {
    "id": 0, 
    "name": "string",
    "description": "string",
    "dueDate": "2024-02-14 15:30", 
    "statusID": 0, 
    "priority": 0, 
    "CreatedID" : 1, 
    "UpdatedID" : 1
  }
}'

Sample JSon Body:
{
  "action": "c", //c: Create; r: Read; u: Update; d: Delete;
  "todoData": {
    "id": 0, // if action is c, then not need also can.
    "name": "string",
    "description": "string",
    "dueDate": "2024-02-14T14:21:46.857Z", //format yyyyy-MM-dd HH:mm
    "statusID": 1, //from commonStatus.cs (1 : Active; 2 : Pending ; 3 : Discontinued ; 4 : Completed ; 5 Not Started)
    "priority": 0, //1 : Urgent; 2 : Not Urgent ; 3 : Relax
    "CreatedID" : 1, // only need it when action is c
    "UpdatedID" : 1
  }


# SQL Reference
1) Create Database in local
2) if using MySQL can look for mySQLScript.sql to create table and insert some default data
3) if using tSQL, can look for tSQLScript.sql to create table and insert some default data

# What can added 
1) put in async 
2) put in tags filter
3) put in completed date, delete date and discontinued date
4) put in sample data of Tags
5) currently this is for 1 person use, may impletement to multiple user.

# Here are some comments from the team manager:
1. Complexity and Technical Challenge: Senior Software Engineer roles typically involve solving complex, high-impact problems. The current project, while a good demonstration of fundamental backend development skills, does not offer a substantial technical challenge that would demonstrate an ability to architect and develop complex systems.

2. System Design and Architecture: The project lacks the depth in system design and architectural decisions that would be indicative of a Senior Software Engineer's strategic thinking and foresight in planning robust systems.

I have taken the time to review your project, and I would like to provide some constructive feedback that may help you refine it. It's clear that you've put effort into this project, and with some adjustments, it could better showcase the skills required for a Senior Software Engineer role.

### Mixing of CRUD Operations
Your approach to combining Create, Read, Update, and Delete (CRUD) functionalities into a single endpoint diverges from commonly accepted design practices. While innovative, this strategy could lead to maintainability challenges and scalability issues as the project grows.

#### Recommendations:
- Separate the CRUD operations into distinct endpoints to provide clarity and adherence to the RESTful API design principles.
- Aim for each endpoint to handle a single responsibility, aligning with the SOLID principles, specifically the Single Responsibility Principle.

### Interface Design
The implementation of commonJsonReturn as a universal response interface might not be the most suitable choice, especially for long-term enterprise projects. This pattern can reduce the flexibility and clarity of the response types returned by your API.

#### Recommendations:
- Define explicit response types for each operation. This provides a clearer contract to the consumers of your API.
- Consider using HTTP status codes effectively to communicate the nature of the response (success, error, etc.).
- Consider making use of Generic https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics

### Code Cleanliness and Professionalism
Leaving sample or boilerplate code within the project can give an impression of inattention to detail. For a Senior Software Engineer, it is crucial to present work that is not only functional but also meticulously reviewed and refined.

#### Recommendations:
- Conduct a thorough code audit to remove any unnecessary or leftover code fragments.
- Implement code linters and formatters to maintain consistent coding standards throughout the project.

### Complexity and Technical Challenge
While the project demonstrates basic backend development skills, it does not reflect the complexity and problem-solving capabilities expected at a senior level.

#### Recommendations:
- Introduce features that require complex business logic or algorithms.
- Incorporate performance optimizations and demonstrate an understanding of scalable system design.

### System Design and Architecture
Currently, the project could benefit from a more in-depth consideration of system design and architectural patterns.

#### Recommendations:
- Illustrate the ability to design for scalability and fault tolerance. This could involve demonstrating a microservices architecture or implementing load balancing.
- Showcase advanced database design, possibly including the use of indexing, complex queries, or data normalization techniques.
- Include aspects of Continuous Integration/Continuous Deployment (CI/CD) to show familiarity with modern deployment practices and DevOps principles.

### Final Thoughts
Your project has the potential to be a strong portfolio piece. By addressing the points above, you can elevate the project to reflect the expertise and the high standards expected from a Senior Software Engineer.

I hope you find this feedback beneficial. Your dedication to your craft is evident, and with these enhancements, you will undoubtedly present a project that showcases your capabilities.
