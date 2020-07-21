using System.ComponentModel.DataAnnotations.Schema;
using DataModels.Base;
using DataModels.Enums;

namespace DataModels.Entities
{
    public class ResearchMember: IdBase
    {
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int ResearchId { get; set; }
        
        [ForeignKey(nameof(ResearchId))]
        public Research Research { get; set; }

        public ResearchMemberLevel Level { get; set; }
    }
}