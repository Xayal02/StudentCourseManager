using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using MediatR;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using StudentsCoursesManager.Application.Authorization.Handlers;
using StudentsCoursesManager.Infrastructure.Repositories;
using StudentsCoursesManager.Infrastructure;
using StudentsCoursesManager.Application.Validators;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Application.Behaviors;

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

            //Validation 
            //services.AddTransient<IValidator<CourseModel>, CourseValidator>();
            services.AddTransient<IValidator<CourseModel>, CourseValidator>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


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


            //Mediator pattern
            services.AddMediatR(Assembly.GetExecutingAssembly());

            

        }
    }
}
