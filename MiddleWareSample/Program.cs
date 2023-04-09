using MiddleWareSample;

var builder = WebApplication.CreateBuilder(args);
///////
//builder.Services.AddTransient<CustomMiddleware>();
//builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.UseWhen(
    context => context.Request.Query.ContainsKey("Username")
    , app =>
     {
         app.UseCustomMiddleware();
         app.Use(async (HttpContext context, RequestDelegate next) =>
             {
                 await context.Response.WriteAsync(" from middleware 1 ");
                 await next(context);
             });
     }
    );

//app.UseMiddleware<CustomMiddleware>();
//app.UseMiddleWareCustom();
//app.UseCustomMiddleware();

app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync(" from middelware 3");
});

app.Run();
