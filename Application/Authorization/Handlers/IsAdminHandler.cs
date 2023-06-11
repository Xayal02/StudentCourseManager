using Microsoft.AspNetCore.Authorization;

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
