using Serilog;
using StudentsCoursesManager.Extensions;
using StudentsCoursesManager.Infrastructure;



Log.Logger = Log.Logger = new LoggerConfiguration().ConfigureLogger();


try
{
    Log.Information("Starting web host"); 

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigureApplication(builder.Configuration);

   Serilog.Debugging.SelfLog.Enable(Console.Error);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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


