using AutoMapper;
using HotelManagementSystem.Data;
using HotelManagementSystem.DTO;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Securities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;

        public SuperAdminService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SuperAdminVM> GetByCredential(string Email, string Password)
        {
            Password = MD5Cryptography.EncryptWithMd5(Password);
            var entity = await _context.SuperAdmins.Where(x => x.IsDeleted == false && x.Email.Equals(Email) && x.Password.Equals(Password)).FirstOrDefaultAsync();
            var admin = _mapper.Map<SuperAdminVM>(entity);
            return admin;
        }
        public async Task<SuperAdminVM> AdminRegister(SuperAdminVM  adminVM)
        {
            SuperAdmin superAdmin = new SuperAdmin() { Password = MD5Cryptography.EncryptWithMd5(adminVM.Password), CreatedAt = DateTime.Now, IsDeleted = false, Email = adminVM.Email };
             _context.SuperAdmins.Add(superAdmin);
            await _context.SaveChangesAsync();
            
            return adminVM;
        }
        public async Task<List<Booking>> GetTotalRoomBooking()
        {
            return await _context.Bookings.Where(x => x.Completed == true && x.IsDeleted == false ).Include(x => x.Guests ).ToListAsync();
        }
        public async Task<List<RoomStoreVM>> GetTotalRRooms()
        {
            var room = await _context.RoomStores.ToListAsync();
            return _mapper.Map<List<RoomStoreVM>>(room);
        }

        public async Task<List<RoomStore>> GetTotalRooms()
        {
            return await _context.RoomStores.Where(x => x.RoomImages != null && x.IsDeleted == false).ToListAsync();
        }

    }
}
