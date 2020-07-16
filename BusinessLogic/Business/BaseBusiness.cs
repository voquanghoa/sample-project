using DataModels;

namespace BusinessLogic.Business
{
    public abstract class BaseBusiness
    {
        protected BkdnContext Context;

        protected BaseBusiness(BkdnContext context)
        {
            this.Context = context;
        }
    }
}