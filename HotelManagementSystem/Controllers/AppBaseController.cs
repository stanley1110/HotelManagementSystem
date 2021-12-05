using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace HotelManagementSystem.Controllers
{
    public abstract class AppBaseController<T> : ControllerBase
    {
        private ILogger<T> logger;
        protected ILogger<T> _logger  => logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();

        [NonAction]
        public long GetAuthenticatedUserId()
        {
            return Convert.ToInt64(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        [NonAction]
        public string GetAuthenticatedUserUniqueName()
        {
            return ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.UniqueName)?.Value;
        }
        [NonAction]
        public string GetIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }


    }
}
