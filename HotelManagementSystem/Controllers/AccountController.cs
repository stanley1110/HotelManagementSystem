using AutoMapper;
using AutoWrapper.Wrappers;
using HotelManagementSystem.DTO;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/account")]
    [AllowAnonymous]
    public class AccountController : AppBaseController<AccountController>
    {
        private readonly IConfiguration config;
        private readonly ISuperAdminService adminService;
        private readonly IStaffService staffService;
        private readonly IGuestService guestService;
        private readonly IMapper _mapper;
        public AccountController(IStaffService staffService,IMapper mapper, IGuestService guestService, IConfiguration config, ISuperAdminService adminService)
        {
            this.staffService = staffService;
            this.guestService = guestService;
            this.config = config;
            _mapper = mapper;
            this.adminService = adminService;
        }

        /// <summary>
        /// Login as admin
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("login-as-admin")]
        public async Task<ApiResponse> LoginAsAdmin([Required(ErrorMessage = "Username not supplied")] string username, [Required(ErrorMessage = "Password not supplied")] string password)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.Values);
            }

            var admin = await adminService.GetByCredential(username, password);

            if (admin == null)
            {
                return new ApiResponse("Invalid credentials", 400);
            }

            var token = JwtHelper.GenerateAdminAuthToken(admin, GetIPAddress(), config);
            return new ApiResponse("Admin token created successfully.", result: new { token = token, role = "admin", isloggedin = true });
        }


        /// <summary>
        /// Login as staff
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("login-as-staff")]
        public async Task<ApiResponse> LoginAsStaff([Required(ErrorMessage = "Username not supplied")] string username, [Required(ErrorMessage = "Password not supplied")] string password)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.Values);
            }

            var staff = await staffService.GetByCredential(username, password);

            if (staff == null)
            {
                return new ApiResponse("Invalid credentials", 400);
            }

          

            var token = JwtHelper.GenerateAgentAuthToken(staff,GetIPAddress(), config);
            return new ApiResponse("staff token created successfully.", result: new { token = token, role = "staff", isloggedin = true });
        }

        /// <summary>
        /// Login as guest
        /// </summary>
        /// <param name="nin"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("login-as-guest")]
        public async Task<ApiResponse> LoginAsGuest([Required(ErrorMessage = "username not supplied")] string username, [Required(ErrorMessage = "Password not supplied")] string password)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.Values);
            }

            var guest = await guestService.GetByCredential(username, password);
            
            if (guest == null )
            {
                return new ApiResponse("Invalid credentials", 400);
            }
            var guestVM = _mapper.Map<GuestVM>(guest);
            var token = JwtHelper.GenerateGuestAuthToken(guestVM,GetIPAddress(), config);
            return new ApiResponse("guest token created successfully.", result: new { token = token, role = "guest", isloggedin = true });
        }



       
    }
}
