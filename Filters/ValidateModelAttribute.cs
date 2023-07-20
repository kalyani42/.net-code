using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GetECIno.Filters
{
    public class ValidateModelAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actioncontext)
        {
            if (!actioncontext.ModelState.IsValid)
            {
                actioncontext.Result = new BadRequestObjectResult(actioncontext.ModelState);
            }
        }
    }
}
