using ConditionalFilter.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ConditionalFilter.Controllers
{
    public class HomeController : ApiController
    {
     
        [HttpGet]
        public HttpResponse AllowGetIndex()
        {
            throw new Exception();
            return null;
        }

    [HttpPost]
        public HttpResponse Index1()
        {
            throw new Exception();
            return null;
        }
    }
}
