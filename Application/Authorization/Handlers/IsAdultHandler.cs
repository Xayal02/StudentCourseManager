using Microsoft.AspNetCore.Authorization;
using StudentsCoursesManager.Domain.Authorization.Requirements;

namespace StudentsCoursesManager.Application.Authorization.Handlers
{
    public class IsAdultHandler : AuthorizationHandler<IsAdult>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdult requirement)
        {
            if (context.User.HasClaim(claim =>
            claim.Type == "Age" &&
            Convert.ToInt16(claim.Value) < 18)) context.Fail();

            return Task.CompletedTask;
        }
    }
}
