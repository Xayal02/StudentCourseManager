using StudentsCoursesManager.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using StudentsCoursesManager.Repository;
using FluentValidation.AspNetCore;
using StudentsCoursesManager.Data.Common;
using System.Text.Json.Serialization;
using MediatR;
using StudentsCoursesManager.Validators;
using System.Reflection;
using FluentValidation;

namespace StudentsCoursesManager.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            //Database connection
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));

            //Validaton Behaviour
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //For mapping entities
            services.AddAutoMapper(typeof(Program).Assembly);


        }
    }
}
