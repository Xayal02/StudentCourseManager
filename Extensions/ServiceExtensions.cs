using StudentsCoursesManager.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using StudentsCoursesManager.Repository;
using FluentValidation.AspNetCore;
using StudentsCoursesManager.Data.Common;

namespace StudentsCoursesManager.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));

            //Adding Fluent Validation


            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
        }
    }
}
