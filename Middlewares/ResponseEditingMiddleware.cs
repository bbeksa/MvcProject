using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  
namespace MvcProject.Middlewares
{
    public class ResponseEditingMiddleware
    {
        private RequestDelegate nextDelegate;
        public ResponseEditingMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
  
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("404 Strona nie istnieje :(");
            }
        }
    }
}