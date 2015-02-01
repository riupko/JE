using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JustEatDemo.Controllers
{
    public class AjaxHandleErrorAttribute : HandleErrorAttribute
    {
        public AjaxHandleErrorAttribute()
        {
            PartialViewName = "PartialError";
        }

        public string PartialViewName { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
            // Execute the normal exception handling routine
            base.OnException(filterContext);
            
            // Check if AJAX request
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //mark as handled
                filterContext.ExceptionHandled = true;

                // Use partial view in case of ajax request
                var result = new PartialViewResult();
                result.ViewName = PartialViewName;
                filterContext.Result = result;
            }
        }
    }
}
