
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
