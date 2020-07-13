using DataModels.Base;

namespace DataModels.Entity
{
    public class Catalog: IdBase
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}