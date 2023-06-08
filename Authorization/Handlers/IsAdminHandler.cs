using Microsoft.AspNetCore.Authorization;

namespace StudentsCoursesManager.Authorization
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
