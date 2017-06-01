using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Linq;
using ConditionalFilter.App_Start;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace ConditionalFilter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            ConfigureValidateCsrfHeaderAttribute();
        }

        private static void ConfigureValidateCsrfHeaderAttribute()
        {
            //Configure a conditional filter
            IList<HttpMethod> nonSafeMethods = new List<HttpMethod> {HttpMethod.Get};

            IEnumerable<Func<HttpConfiguration, HttpActionDescriptor, object>> conditions =
                new Func<HttpConfiguration, HttpActionDescriptor, object>[] {

                ( c, a ) => a.ActionName.Contains("AllowGet")?//nonSafeMethods.Any(m => a.SupportedHttpMethods.Contains(m)) ?
                new AllowReadAccessAttribute() : null
    };

            System.Web.Http.Filters.IFilterProvider provider = new ConditionalFilterProvider(conditions);

            // This line adds the filter we created above
            GlobalConfiguration.Configuration.Services.Add(typeof( System.Web.Http.Filters.IFilterProvider), provider);
        }
    }
}