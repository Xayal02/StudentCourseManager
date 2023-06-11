using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace StudentsCoursesManager.Application.Authorization.Handlers
{
    public class IsAuthenticatedUserHandler : AuthorizationHandler<IsAllowedToReadData>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAllowedToReadData requirement)
        {
            if (context.User.HasClaim(claim => claim.Type == ClaimTypes.Role && claim.Value is "User" or "Admin")) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
