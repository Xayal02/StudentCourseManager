using Microsoft.AspNetCore.Authorization;
using StudentsCoursesManager.Domain.Authorization.Requirements;

namespace StudentsCoursesManager.Application.Authorization.Handlers
{
    public class IsAdminHandler : AuthorizationHandler<IsAllowedToModifyData>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAllowedToModifyData requirement)
        {
            if (context.User.IsInRole("Admin")) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
