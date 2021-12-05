
using HotelManagementSystem.Data;
using HotelManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Interface
{
    public interface ISuperAdminService
    {
        Task<SuperAdminVM> GetByCredential(string Username, string Password);
        Task<SuperAdminVM> AdminRegister(SuperAdminVM adminVM);
        Task<List<Booking>> GetTotalRoomBooking();
        Task<List<RoomStore>> GetTotalRooms();
    }
}
