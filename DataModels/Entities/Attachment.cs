using System;
using System.ComponentModel.DataAnnotations.Schema;
using DataModels.Base;

namespace DataModels.Entities
{
    public class Attachment: IdBase
    {
        public string Name { get; set; }

        public DateTime UploadDateTime { get; set; }

        public Guid AccessCode { get; set; }
        
        public int ResearchId { get; set; }
        
        [ForeignKey(nameof(ResearchId))]
        public Research Research { get; set; }
    }
}