using System;
using DataModels.Base;

namespace DataModels.Entities
{
    public class Photo: IdBase
    {
        public Guid AccessId { get; set; }
        
        public string MineType { get; set; }

        public byte[] Data { get; set; }

        public DateTime UploadedDate { get; set; }
    }
}