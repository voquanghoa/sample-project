using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataModels.Base;
using DataModels.Enums;

namespace DataModels.Entity
{
    public class Topic: IdBase
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int? MentorId { get; set; }
        
        [ForeignKey(nameof(MentorId))]
        public Employee Mentor { get; set; }

        public TopicLevel Level { get; set; }

        public List<TopicMember> Members { get; set; } = new List<TopicMember>();

        public List<Catalog> Catalogs { get; set; }

        public int EndYear { get; set; }

        public int Progress { get; set; }

        public decimal Cost { get; set; }

        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        
        public int? ValidatorId { get; set; }
        
        [ForeignKey(nameof(ValidatorId))]
        public Employee Validator { get; set; }
    }
}