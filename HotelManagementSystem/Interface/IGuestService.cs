
using HotelManagementSystem.Data;
using HotelManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Interface
{
    public interface IGuestService
    {
        Task<GuestVM> CreateGuest(GuestVM  guestVM);

        Task<string> BookGuestRoom(int username, int roomid);
        Task<string> UpdateGuest(GuestVM guestVM);


        Task<string> CancelBooking(string email);
        Task<GuestVM> GetByCredential(string username, string password);





     


       
    }
}
