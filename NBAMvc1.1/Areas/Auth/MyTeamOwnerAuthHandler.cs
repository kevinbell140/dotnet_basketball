using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Areas.Auth
{
    public class MyTeamOwnerAuthHandler : AuthorizationHandler<OperationAuthorizationRequirement, MyTeam>
    {
        UserManager<ApplicationUser> _userManager;
        public MyTeamOwnerAuthHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, MyTeam resource)
        {
            if(context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if(requirement.Name != Constants.CreateOperationName && requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName && requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            if(resource.UserID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
