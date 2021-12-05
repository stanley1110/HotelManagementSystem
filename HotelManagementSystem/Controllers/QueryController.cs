using AutoWrapper.Wrappers;
using HotelManagementSystem.DTO;
using HotelManagementSystem.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Route("api/query")]
    [ApiController]
    public class QueryController : Controller
    {
        public IGuestService  guestService { get; set; }
        public IStaffService  staffService { get; set; }
        public ISuperAdminService  superAdminService { get; set; }

        public QueryController(IGuestService guestService, IStaffService staffService, ISuperAdminService superAdminService)
        {
            this.guestService = guestService;
            this.staffService = staffService;
            this.superAdminService = superAdminService;
         
        }
        /// <summary>
        /// create guest
        /// </summary>
        /// <returns></returns>
        [HttpPost("create-guest")]
        public async Task<ApiResponse> CreateGuest(GuestVM guestVM)
        {
            try
            {
                var guest = await guestService.CreateGuest(guestVM);


                return new ApiResponse("Guest account has been created succefully successfully.", result: guest);
            }
            catch (Exception x)
            {
                throw new ApiException(x);
            }
        }
        /// <summary>
        /// create Admnin
        /// </summary>
        /// <returns></returns>
        [HttpPost("create-admin")]
        public async Task<ApiResponse> CreateAdmin(SuperAdminVM  superAdminVM)
        {
            try
            {
                var guest = await superAdminService.AdminRegister(superAdminVM);


                return new ApiResponse("Admin account has been created succefully successfully.", result: guest);
            }
            catch (Exception x)
            {
                throw new ApiException(x);
            }
        }
        /// <summary>
        /// Create Staff
        /// </summary>
        /// <returns></returns>
        [HttpPost("create-staff")]
        public async Task<ApiResponse> CreateStaff(StaffVM staffVM)
        {
            try
            {
                var result = await staffService.CreateStaff(staffVM, null);
                return new ApiResponse("Staff account has been created succefully successfully.",result: result);
            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }

    }
}
