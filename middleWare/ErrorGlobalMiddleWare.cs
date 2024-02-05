using Serilog;

namespace Project.middleWare
{
    public class ErrorGlobalMiddleWare
    {

        private readonly RequestDelegate _next;

        public ErrorGlobalMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error("message: " + ex.Message);
            }
        }
    }
}
