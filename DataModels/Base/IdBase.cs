using System.ComponentModel.DataAnnotations;

namespace DataModels.Base
{
    public class IdBase
    {
        [Key]
        public int Id { get; set; }
    }
}