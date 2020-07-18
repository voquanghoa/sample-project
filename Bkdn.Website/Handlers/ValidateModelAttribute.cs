using System.Linq;
using Bkdn.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bkdn.Website.Handlers
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                var message = context.ModelState.Values.First().Errors[0].ErrorMessage;
                context.Result = new BadRequestObjectResult(new ErrorModel(message));
            }
        }
    }
}