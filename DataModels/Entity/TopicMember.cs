using System.ComponentModel.DataAnnotations.Schema;
using DataModels.Base;
using DataModels.Enums;

namespace DataModels.Entity
{
    public class TopicMember: IdBase
    {
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int TopicId { get; set; }
        
        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; }

        public TopicMemberLevel Level { get; set; }
    }
}