using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public string CompensationId { get; set; }
        public Employee Employee { get; set; }
        public double Salary { get; set; }
        public DateTime EffectiveDate { get; set; }

        public Compensation()
        {
        }

        // public Compensation(Employee employee, double salary, DateTime effectiveDate)
        // {
        //     this.Employee = employee;
        //     this.Salary = salary;
        //     this.EffectiveDate = effectiveDate;
        // }
    }
}