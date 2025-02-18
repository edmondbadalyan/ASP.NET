using Microsoft.AspNetCore.Authorization;

internal class GameCreationAuthorizationHandler : AuthorizationHandler<GameCreationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GameCreationRequirement requirement)
    {
        
        if (context.User.HasClaim(c => c.Type == "CanCreateGame" && c.Value == "true"))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
