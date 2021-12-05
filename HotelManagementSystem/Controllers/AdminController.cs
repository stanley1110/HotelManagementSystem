using AutoWrapper.Wrappers;
using HotelManagementSystem.DTO;
using HotelManagementSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Route("api/staff")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminController : AppBaseController<AdminController>
    {
        private readonly IStaffService staffService;
   
     
        private readonly ISuperAdminService superAdminService;


        public AdminController(IStaffService staffService, IGuestService guestService,ISuperAdminService superAdminService)
        {
            try
            {
                this.staffService = staffService;

                this.superAdminService = superAdminService;
            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }
        /// <summary>
        /// Fetches all bookings
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-bookings")]
        public async Task<ApiResponse> GetBookings()
        {
            try
            {
                var result = await superAdminService.GetTotalRoomBooking();
                return new ApiResponse(result: result);
            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }
        /// <summary>
        /// Fetches all bookings
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-rooms")]
        public async Task<ApiResponse> Getrooms()
        {
            try
            {
                var result = await superAdminService.GetTotalRooms();
                return new ApiResponse(result: result);
            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }

        /// <summary>
        /// Creates a staff by authenticated Admin
        /// </summary>
        /// <param name="staffVM"></param>

        /// <returns></returns>
        [HttpPost("create-staff")]
        public async Task<ApiResponse> CreateStaff([Required(ErrorMessage = "informations needed not supplied")] StaffVM staffVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiException(ModelState.Values);
                }

                //check if account already exists
                var adminName = GetAuthenticatedUserUniqueName();
                var adminId = GetAuthenticatedUserId();
                var admin = await staffService.CreateStaff(staffVM, adminName);




                return new ApiResponse($"Staff created successfully by {adminName}", result: admin, 200);
            }
            catch (Exception x)
            {
                throw new ApiException(x);
            }
        }




        /// <summary>
        /// remove staff
        /// </summary>
        /// <returns></returns>
        [HttpDelete("remove-staff")]
        public async Task<ApiResponse> RemoveStaff(long id)
        {
            var adminName = GetAuthenticatedUserUniqueName();
            var staff = await staffService.GetById( id);
            if (staff == null)
            {
                return new ApiResponse("Staff not found");
            }
          
            await staffService.DeleteStaff(id);
            return new ApiResponse($"Staff successfully removed by {adminName} ");
        }

    



        
    } 
}
