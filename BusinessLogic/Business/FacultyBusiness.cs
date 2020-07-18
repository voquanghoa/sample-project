using DataModels;
using DataModels.Entities;

namespace BusinessLogic.Business
{
    public class FacultyBusiness: GenericBusiness<Faculty>
    {
        public FacultyBusiness(BkdnContext context) : base(context)
        {
        }
    }
}