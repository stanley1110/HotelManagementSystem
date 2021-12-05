using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Interface;
using HotelManagementSystem.DTO;
using HotelManagementSystem.Data;
using HotelManagementSystem.Securities;

namespace HotelManagementSystem.Services
{
    public class GuestService : IGuestService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
      

        public GuestService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }




        public async Task<GuestVM> CreateGuest(GuestVM guestVM)
        {

            var guest = _mapper.Map<Guest>(guestVM);
            guest.CreatedAt = DateTime.Now;
            guest.IsDeleted = false;
            guest.Email = guestVM.Email;
            guest.Password = MD5Cryptography.EncryptWithMd5(guestVM.Password);
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return _mapper.Map<GuestVM>(guest);
            
          
        }


        public async Task<string> CancelBooking(string email)
        {
            var entity = await _context.Bookings.Where(x=> x.IsDeleted == false && x.Guests.Email == email).FirstOrDefaultAsync();
            string status = "";
            if (entity != null)
            {

                _context.Remove(entity);
                await _context.SaveChangesAsync();
                status = "success";
            }
            return status;
        }

        public async Task<GuestVM> GetByCredential(string username, string password)

        {
            password = MD5Cryptography.EncryptWithMd5(password);
            var entity = await _context.Guests.Where(x => x.IsDeleted == false && x.Email.Equals(username) && x.Password.Equals(password)).FirstOrDefaultAsync();
            var guest = _mapper.Map<GuestVM>(entity);
            return guest;
        }

        public async void BookRoom(long Id, string name)

        {
        
            var room =  _context.RoomStores.Find(Id);
            room.Available = false;
            room.Name = name;

            
        }




            public async Task<string> BookGuestRoom(int guestid, int roomid)
        {
            string status = "";
            var guestVM = await _context.Guests.Where(x => x.IsDeleted == false && x.Id == guestid).FirstOrDefaultAsync();
            var room = await _context.RoomStores.Where(x => x.Available == true && x.IsDeleted == false && x.Id == roomid).FirstOrDefaultAsync();
            BookRoom(roomid, guestVM.FirstName);

            if (room != null)
            {
                Booking booking1 = new Booking();

                booking1.Room = room.Name;
                booking1.CheckIn = DateTime.Now;
                booking1.Completed = true;
                booking1.Guests = guestVM;
                room.Available = false;
                _context.Bookings.Add(booking1);
                await _context.SaveChangesAsync();
                status = "room booking success";
            }
            else { status = "room booking failed"; }
            return status;
        }


        public async Task<string> UpdateGuest(GuestVM guestVM)
        {
            string success = "";

            try
            {
                var entity =  _context.Guests.Find( guestVM.Id);
                if (entity != null)
                {
                    var guest = _mapper.Map<Guest>(guestVM);
             

                    guest.Password = MD5Cryptography.EncryptWithMd5(guestVM.Password);
                    guest.IsDeleted = false;
                     
                    guest.ModifiedBy = guestVM.Email;

                    guest.ModifiedAt = DateTime.Now;
                   
                    _context.Entry(entity).CurrentValues.SetValues(guest);
                    success = "success";

                }
                 _context.SaveChanges();
                if (entity == null)
                {
                    success= "success";
                }

                return success;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
    
    
}
