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
    public class StaffService : IStaffService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;

        public StaffService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StaffVM> CreateStaff(StaffVM StaffVM, string? adminName)
        {
            Staff staff = null;
            if (adminName != null)
            {
                 
                staff.CreatedAt = DateTime.Now;
                staff.ApprovalAdmin = adminName;
                staff.FirstName = StaffVM.FirstName;
                staff.LastName = StaffVM.LastName;
                staff.Gender = StaffVM.Gender;
                staff.IsDeleted = false;
                staff.PhoneNo = staff.PhoneNo;
                staff.Username = StaffVM.Email;
                staff.Password = MD5Cryptography.EncryptWithMd5(StaffVM.Password);
                
            }
            else
            {
                 staff = _mapper.Map<Staff>(StaffVM);
                staff.CreatedAt = DateTime.Now;
                staff.FirstName = StaffVM.FirstName;
                staff.LastName = StaffVM.LastName;
                staff.Gender = StaffVM.Gender;
                staff.IsDeleted = false;
                staff.PhoneNo = staff.PhoneNo;
                staff.Username = StaffVM.Email;
                staff.Password = MD5Cryptography.EncryptWithMd5(StaffVM.Password);
            }
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
            return _mapper.Map<StaffVM>(staff);
        }

       

        public async Task<StaffVM>  GetByCredential(string username, string password)
       
        {
            password = MD5Cryptography.EncryptWithMd5(password);
            var entity = await _context.Staffs.Where(x => x.IsDeleted == false && x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefaultAsync();
            var staff = _mapper.Map<StaffVM>(entity);
            return staff;
        }

        public async Task<string> CreateRooms(RoomStoreVM  roomStore)
        {
            var room = _mapper.Map<RoomStore>(roomStore);
            room.Name = roomStore.RoomNo;
            room.CreatedAt = DateTime.Now;
            room.Available = true;
            room.IsDeleted = false;
             _context.RoomStores.Add(room);
            await _context.SaveChangesAsync();
            return "Successfull";
        }
        public async Task<string> EditRooms(RoomStoreVM roomStore)
        {
            string success = "";

            var entity = _context.RoomStores.Find(roomStore.Id);
            if (entity != null)
            {
                var room = _mapper.Map<RoomStore>(roomStore);
                room.IsDeleted = false;
                room.Available = true;
                room.ModifiedAt = DateTime.Now;
                room.Name = roomStore.RoomNo;
           
                _context.Entry(entity).CurrentValues.SetValues(room);
                success = "success";

            }
            _context.SaveChanges();
            if (entity == null)
            {
                success = "success";
            }
            return success;
        }

        public async Task<StaffVM> GetById(long id)
        
        {
            var entity =  _context.Staffs.Find(id);
            var staff = _mapper.Map<StaffVM>(entity);
            return staff;
        }
        public async Task<RoomStore> RoomAvailabilityCHeck(string roomno)

        {
            var entity = await _context.RoomStores.Where(x => x.IsDeleted == false && x.Name.Equals(roomno) && x.Available == true).FirstOrDefaultAsync();
           
            return entity;
        }







        //public async Task RemoveStaff(long Id, string adminName)
        //{
        //    var entity = await _context.Staffs.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefaultAsync();
        //    if (entity != null )
        //    {
        //        entity.ModifiedBy = adminName;
        //        entity.IsDeleted = true;
        //        entity.ModifiedAt = DateTime.Now;
        //        await _context.SaveChangesAsync();
        //    }
        //}
        public async Task<string> UpdateStaff(StaffVM  staffVM, string username)
        {
            string success = "";
            try
            {
                var entity = _context.Staffs.Find(staffVM.Id);
                if (entity != null)
                {
                    var staff = _mapper.Map<Staff>(staffVM);
                    staff.IsDeleted = false;
                    staff.ModifiedAt = DateTime.Now;
                    staff.ModifiedBy = username;

                    _context.Entry(entity).CurrentValues.SetValues(staff);
                    success = "success";

                }
                _context.SaveChanges();
                if (entity == null)
                {
                    success = "success";
                }
                return success;

            }
            catch (Exception x)
            {
                throw x;
            }
        }
       
        public async Task<Staff> DeleteStaff(long Id)
        {
            var entity =  _context.Staffs.Find(Id); 
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }




    }
}
