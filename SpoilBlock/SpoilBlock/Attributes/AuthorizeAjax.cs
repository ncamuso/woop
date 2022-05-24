using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;

namespace SpoilBlock.Attributes
{



    public static class HttpRequestExtensions
    {
        private const string RequestedWithHeader = "validate-ajax";
        private const string AjaxHeader = "true";

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers != null)
            {
                return request.Headers[RequestedWithHeader] == AjaxHeader;
            }

            return false;
        }
    }

    public class AuthorizeAjaxAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest();
        }
    }

}
