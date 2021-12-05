
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System;
using HotelManagementSystem.Interface;
using HotelManagementSystem.DTO;

namespace HotelManagementSystem.Controllers
{
    [Route("api/staff")]
    [Authorize(Roles = "Staff")]
    [ApiController]
    public class StaffController : AppBaseController<StaffController>
    {
   
        private readonly IStaffService  staffService;
       
      
        public StaffController( IStaffService  staffService)
        {
         
            this.staffService = staffService;
        }

       
        /// <summary>
        /// Creates Room by Staff
        /// </summary>
        /// <param name="roomStore"></param>
        /// <returns></returns>
        [HttpPost("create-room")]
        public async Task<ApiResponse> CreateRooms([Required(ErrorMessage = "Room data not supplied")] RoomStoreVM roomStore)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiException(ModelState.Values);
                }
                var adminid = GetAuthenticatedUserId();
                var adninname = GetAuthenticatedUserUniqueName();
              var result =  await staffService.RoomAvailabilityCHeck(roomStore.RoomNo);
                if (result == null)
                {
                    await staffService.CreateRooms(roomStore);
                    return new ApiResponse("Room successfully created");
                }
                else
                {
                    return new ApiResponse("Room number already taken");
                }
            }
            catch (Exception x)
            {
                throw new ApiException(x);
            }
        }

        /// <summary>
        /// Update Staff details by Staff
        /// </summary>
        /// <param name="staffVM"></param>
        /// <returns></returns>
        [HttpPatch("update-staff-details")]
        public async Task<ApiResponse> UpdateStaff(StaffVM  staffVM)
        {
            string message = "";
           
            try
            {
                var result = await  staffService.UpdateStaff(staffVM, staffVM.Email);
                if (result == "success")
                { 
                   message = "Staff details successfully updated";
                }
                else
                {
                    message = "staff details update unsuccessfull";
                }
                return new ApiResponse(message);


            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }

        /// <summary>
        /// Update Room details by Staff
        /// </summary>
        /// <returns></returns>
        [HttpPatch("update-Room-details")]
        public async Task<ApiResponse> UpdateRoom(RoomStoreVM  roomStoreVM)
        {
            string message = "";

            try
            {
                var result = await staffService.EditRooms(roomStoreVM);
                if (result == "success")
                {
                    message = "Room details successfully updated";
                }
                else
                {
                    message = "Room details update unsuccessfull";
                }
                return new ApiResponse(message);


            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }
    }
}
