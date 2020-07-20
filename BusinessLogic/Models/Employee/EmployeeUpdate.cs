using System;
using DataModels.Base;

namespace BusinessLogic.Models.Employee
{
    public class EmployeeUpdate: IdBase
    {
        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public int? Sex { get; set; }

        public int? FacultyId { get; set; }
    }
}