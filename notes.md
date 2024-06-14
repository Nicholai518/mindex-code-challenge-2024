
## DirectReports are null in tests

Noticed that DirectReports were null in the response from GetEmployeeById...

Added a unit test to test the null DirectReports field.

Found the code where the database is setup in the EmployeeDataSeeder... the DirectReports look fine there...

Is the database getting messed up somehow after EmployeeDataSeeder does its work?

Found this stack overflow article about in memory DB: https://stackoverflow.com/questions/50530949/ef-core-2-1-in-memory-db-not-updating-records


## Task one

Create ReportingStructure
- Employee
- NumberOfReports

Create method within ReportingStructure to determine the number of reports for the employee 

"Traverse a binary tree" to get the number of reports for an employee
https://stackoverflow.com/questions/443695/traversing-a-tree-of-objects-in-c-sharp

Create GET endpoint 

Use Postman to test endpoint

Write tests:
Write a test for John Lennon to confirm 4 Direct Reports
Write a test for Paul McCartney to confirm 0 Direct Reports
Write a test for an invalid employee id


### Task 2
Create Compensation
- Employee
- Salary
- Effective Date

Create two new Compensation REST endpoints: 
- POST
- Inlcude employee id in POST request, does not make sense to include entire employee
- Then use the employee service to get the employee for Compensation

- GET (EmployeeID)

 These should persist and query the Compensation from the persistence layer.

 Naming Error: "EmployeeRespository.cs"


Write tests:
Write a test to create compensation for John Lennon  (Successful)
Write a test to create and read compensation for Paul McCartney (Successful)


### Final thoughts / Steps
- Solved bug / issue with Direct Reports and in-memory db
- All endpoints working correctly
- All tests run successfully: Open "Tests" file > "Run All" > All Successful
- Make git repo public
- Respond to Mark's email
