namespace MiddleWareSample
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync(" From middleware 2 - Start");
            await next(context);
            await context.Response.WriteAsync(" From middleware 2 - End");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMiddleWareCustom(this WebApplication webApplication)
        {
            return webApplication.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
