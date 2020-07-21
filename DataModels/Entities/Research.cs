using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataModels.Base;
using DataModels.Enums;

namespace DataModels.Entities
{
    public class Research: IdBase
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int? MentorId { get; set; }
        
        [ForeignKey(nameof(MentorId))]
        public Employee Mentor { get; set; }

        public ResearchLevel Level { get; set; }

        public virtual List<ResearchMember> Members { get; set; } = new List<ResearchMember>();

        public virtual Catalog Catalog { get; set; }

        public int EndYear { get; set; }

        public int Progress { get; set; }

        public decimal Cost { get; set; }

        public virtual List<Attachment> Attachments { get; set; } = new List<Attachment>();
        
        public int? ValidatorId { get; set; }
        
        [ForeignKey(nameof(ValidatorId))]
        public virtual Employee Validator { get; set; }
    }
}