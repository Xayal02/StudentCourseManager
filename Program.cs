using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using StudentsCoursesManager.Data.Common;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Data.Validators;
using StudentsCoursesManager.Extensions;
using StudentsCoursesManager.Helpers;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Repository;
using StudentsCoursesManager.Validators;
using System.Reflection;
using System.Text.Json.Serialization;



Log.Logger = new LoggerConfiguration().ConfigureLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigureApplication(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddLogging();

    var app = builder.Build();

    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
    dataContext?.Database.EnsureCreated();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();


    app.MapControllers();

    app.UseErrorHandler();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush(); //dispose logger and the end
}


