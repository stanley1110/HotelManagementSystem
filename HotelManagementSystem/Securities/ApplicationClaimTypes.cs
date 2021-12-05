using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Securities
{
    /// <summary>
    /// This is the claim types for this application
    /// </summary>
    //
    // Summary:
    //     List of registered claims from different sources http://tools.ietf.org/html/rfc7519#section-4
    //     http://openid.net/specs/openid-connect-core-1_0.html#IDToken
    public struct ApplicationClaimTypes
    {
        public static string LastName { get; } = $" { typeof(ApplicationClaimTypes).FullName}.{nameof(LastName)}";
        public static string FirstName { get; } = $" { typeof(ApplicationClaimTypes).FullName}.{nameof(FirstName)}";
        public static string AgentName { get; } = $" { typeof(ApplicationClaimTypes).FullName}.{nameof(AgentName)}";
        public static string IpAddress { get; } = $" { typeof(ApplicationClaimTypes).FullName}.{nameof(IpAddress)}";
    }
}
