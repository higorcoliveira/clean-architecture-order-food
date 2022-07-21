using OrderFood.Application;
using OrderFood.Infrastructure;
using OrderFood.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, OrderFoodProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseExceptionHandler("/errors");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
