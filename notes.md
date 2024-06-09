
## DirectReports are null in tests

Noticed that DirectReports were null in the response from GetEmployeeById...

Added a unit test to test the null DirectReports field.

Found the code where the database is setup in the EmployeeDataSeeder... the DirectReports look fine there...

Is the database getting messed up somehow after EmployeeDataSeeder does its work?

Found this stack overflow article about in memory DB: https://stackoverflow.com/questions/50530949/ef-core-2-1-in-memory-db-not-updating-records

