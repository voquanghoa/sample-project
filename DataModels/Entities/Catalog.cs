using DataModels.Base;

namespace DataModels.Entities
{
    public class Catalog: IdBase
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}