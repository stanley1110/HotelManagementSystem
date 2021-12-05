

using HotelManagementSystem.Data;
using HotelManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Interface
{
    public interface IStaffService
    {
        Task<StaffVM> CreateStaff(StaffVM StaffVM, string? adminName);
        Task<StaffVM> GetById(long id);
        Task<RoomStore> RoomAvailabilityCHeck(string roomno);
        Task<string> UpdateStaff(StaffVM staffVM, string name);

        Task<StaffVM> GetByCredential(string username, string password);
        Task<string> CreateRooms(RoomStoreVM roomStore);
        Task<string> EditRooms(RoomStoreVM roomStore);
        Task<Staff> DeleteStaff(long  id);


    }
}
