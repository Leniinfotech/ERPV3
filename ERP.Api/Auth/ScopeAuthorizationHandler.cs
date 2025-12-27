using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ERP.Api.Auth
{
    public sealed class ScopeRequirement : IAuthorizationRequirement
    {
        public string Scope { get; }
        public ScopeRequirement(string scope) => Scope = scope;
    }

    public sealed class ScopeAuthorizationHandler : AuthorizationHandler<ScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ScopeRequirement requirement)
        {
            var scopes = context.User.FindAll("scope").Select(c => c.Value).ToHashSet();
            if (scopes.Contains(requirement.Scope))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}