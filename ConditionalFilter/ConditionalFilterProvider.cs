using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ConditionalFilter
{
    public class ConditionalFilterProvider : IFilterProvider
    {
        private readonly
          IEnumerable<Func<HttpConfiguration, HttpActionDescriptor, object>> _conditions;

        public ConditionalFilterProvider(
          IEnumerable<Func<HttpConfiguration, HttpActionDescriptor, object>> conditions)
        {

            _conditions = conditions;
        }

        public IEnumerable<FilterInfo> GetFilters(
            HttpConfiguration controllerContext,
            HttpActionDescriptor actionDescriptor)
        {
            return from condition in _conditions
                   select condition(controllerContext, actionDescriptor) into filter
                   where filter != null
                   select new FilterInfo(filter as IFilter, FilterScope.Global);
        }
    }
}