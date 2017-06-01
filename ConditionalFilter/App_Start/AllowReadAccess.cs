using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace ConditionalFilter.App_Start
{
    public class AllowReadAccessAttribute :  ActionFilterAttribute
    {
        public bool AllowMultiple { get {return false;}}
        //public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    IsAjaxRequest(actionExecutedContext.Request);
        //    var test  =  actionExecutedContext.ActionContext.ActionDescriptor;
           
        //    return null; 
        //}

        public class AjaxOnlyAttribute : System.Web.Http.Filters.ActionFilterAttribute
        {

            public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
            {

                var request = actionContext.Request;

                var headers = request.Headers;

                if (!headers.Contains("X-Requested-With") || headers.GetValues("X-Requested-With").FirstOrDefault() != "XMLHttpRequest")

                    actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);

            }

        }

    }
}
