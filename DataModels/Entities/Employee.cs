using System;
using System.ComponentModel.DataAnnotations.Schema;
using DataModels.Base;

namespace DataModels.Entities
{
    public class Employee: IdBase
    {
        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public int? Sex { get; set; }

        public int? FacultyId { get; set; }
        
        [ForeignKey(nameof(FacultyId))]
        public Faculty Faculty { get; set; }
    }
}