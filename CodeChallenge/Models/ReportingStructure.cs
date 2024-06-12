namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
        public Employee Employee { get; }
        public int NumberOfReports { get; private set; }

        public ReportingStructure(Employee employee)
        {
            this.Employee = employee;
            FindNumberOfReports(employee);
        }

        private void FindNumberOfReports(Employee employee)
        {
            if (employee.DirectReports == null)
            {
                return;
            }

            foreach (Employee report in employee.DirectReports)
            {
                this.NumberOfReports++;
                FindNumberOfReports(report);
            }
        }
    }
}