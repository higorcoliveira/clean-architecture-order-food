using OrderFood.Api.Controllers;
using OrderFood.Application;
using OrderFood.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    // builder.Services.AddControllers(opt => opt.Filters.Add<ErrorHandlerFilterAttribute>());
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, OrderFoodProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseExceptionHandler("/errors");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
