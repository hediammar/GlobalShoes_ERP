using System;
using System.Collections.Generic;

namespace WpfAppGlobalShoes.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; } // Primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? SupervisorID { get; set; } // Nullable if the employee doesn't have a supervisor
        public string EmploymentStatus { get; set; }

        public ICollection<Sale> Sales { get; set; }
        public ICollection<Charge> Charges { get; set; }

    }
}
