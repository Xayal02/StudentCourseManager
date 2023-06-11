//using Microsoft.AspNetCore.Diagnostics;
//using System.ComponentModel.DataAnnotations;

//namespace StudentsCoursesManager.Extensions
//{
//    public static class ValidationExtension
//    {
//        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
//        {
//            app.UseExceptionHandler(x =>
//            {
//                x.Run(async context =>
//                {
//                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
//                    var exception = errorFeature.Error;

//                    //if (!(exception is ValidationException validationException))
//                    //{
//                    //    throw exception;
//                    //}

//                    //var errors = validationException
//                })
//            })
//        }
//    }
//}
