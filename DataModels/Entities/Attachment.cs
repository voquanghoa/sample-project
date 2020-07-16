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
        public int TopicId { get; set; }
        
        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; }
    }
}