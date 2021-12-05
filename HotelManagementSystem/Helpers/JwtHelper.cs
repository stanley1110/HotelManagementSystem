
using HotelManagementSystem.DTO;
using HotelManagementSystem.Securities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Helpers
{
    public class JwtHelper
    {
        public static string GenerateGuestAuthToken(GuestVM  guestVM, string ipaddress,  IConfiguration _config)
        {
           
                List<Claim> claims = new()
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, guestVM.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, guestVM.Email ?? string.Empty),
                    new Claim(ApplicationClaimTypes.IpAddress, ipaddress),
                    new Claim(ClaimTypes.NameIdentifier, guestVM.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Guest"),
                };
                return GenerateJSONWebToken(claims, _config);
            }

            public static string GenerateAdminAuthToken(SuperAdminVM admin, string ipaddress, IConfiguration _config)
            {
                List<Claim> claims = new()
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, admin.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ApplicationClaimTypes.IpAddress, ipaddress),
                    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                };
                return GenerateJSONWebToken(claims, _config);
            }

            public static string GenerateAgentAuthToken(StaffVM agent, string ipaddress, IConfiguration _config)
            {
                List<Claim> claims = new()
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, agent.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, agent.Email ?? string.Empty),
                    new Claim(ApplicationClaimTypes.IpAddress, ipaddress),
                    new Claim(ApplicationClaimTypes.AgentName, agent.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, agent.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Staff"),
                };
                return GenerateJSONWebToken(claims, _config);
            }

            private static string GenerateJSONWebToken(List<Claim> claims, IConfiguration _config)
        {
            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
              _config["JwtSettings:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"])), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
