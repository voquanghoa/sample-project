using System;

namespace BusinessLogic.Models.Employee
{
    public class EmployeeCreate
    {
        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public int? Sex { get; set; }

        public int? FacultyId { get; set; }
    }
}