
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using System;
using HotelManagementSystem.Interface;
using HotelManagementSystem.DTO;

namespace HotelManagementSystem.Controllers
{
    [Route("api/guest")]
    [Authorize(Roles = "Guest")]
    [ApiController]
    public class GuestController 
    {
       
        private readonly IGuestService guestService;
     
       
        public GuestController(  IGuestService  guestService)
        {
           
          
            this.guestService = guestService;
           
        }

      

        /// <summary>
        ///Books GuestRoom
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost("Book-GuestRoom")]
        public async Task<ApiResponse> BookGuestRoom(int guestid, int roomid)
        {
            try
            {
                var result = await guestService.BookGuestRoom(guestid, roomid);


                return new ApiResponse(result: result);
            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }

        /// <summary>
        ///cancels booking
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("cancel-room-booking")]
        public async Task<ApiResponse> CancelRoomBooking(string email)
        {
            try
            {
                await guestService.CancelBooking(email);
                return new ApiResponse("Booking cancelled successfully.");
            }
            catch (System.Exception x)
            {
                throw new ApiException(x);
            }
        }

        /// <summary>
        /// Update guest details by Guest
        /// </summary>
        /// <param name="guestVM"></param>
        /// <returns></returns>
        [HttpPatch("update-guest-details")]
        public async Task<ApiResponse> Updateguest(GuestVM  guestVM)
        {
            string message = "";

            try
            {
                var result = await  guestService.UpdateGuest( guestVM);
                if (result == "success")
                {
                    message = "Guest details successfully updated";
                }
                else
                {
                    message = "Guest details update unsuccessfull";
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
