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
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Data.Validators;
using StudentsCoursesManager.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using StudentsCoursesManager.Authorization.Handlers;

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
            services.AddTransient<IValidator<CourseModel>, CourseValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //For mapping entities
            services.AddAutoMapper(typeof(Program).Assembly);

            //Authentication
            var signingKey = configuration["Jwt:SigningKey"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = "example.com",
                      ValidAudience = "example.com",
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
                  };
              });

            //Authorization rules

            services.AddSingleton<IAuthorizationHandler, IsAdminHandler>();
            services.AddSingleton<IAuthorizationHandler, IsAuthenticatedUserHandler>();
            services.AddSingleton<IAuthorizationHandler, IsAdultHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthenticatedUser",
                    policy => policy.AddRequirements(new IsAllowedToReadData()));

                options.AddPolicy("AdminOnly",
                    policy => policy.AddRequirements(new IsAllowedToModifyData()));
            });


        }
    }
}
