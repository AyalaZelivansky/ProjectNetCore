
using Serilog;

namespace Project.middleWare
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var myAction = httpContext.GetRouteData().Values["action"]?.ToString();
            Log.Information("action:" + " " + myAction);
            Log.Information("from new middleware");
            await _next(httpContext);
        }
    }
}
