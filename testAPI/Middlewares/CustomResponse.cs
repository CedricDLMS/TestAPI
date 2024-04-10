using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using testAPI.Controllers;
using testAPI.IServices;

namespace testAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomResponse
    {
        private readonly RequestDelegate _next;

        public CustomResponse(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            if(httpContext.Response.StatusCode == 999)
            {
                //await httpContext.Response.Redirect("/images/ERREUR.jpg" + httpContext.Request.Host.Value + httpContext.Request.Path, false);
                await httpContext.Response.WriteAsync("ERREUR");
                //await httpContext.Response.Redirect("https://localhost:7158/api/ExoRoute/GetImage",false,false);
                
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomResponse>();
        }
    }
}
