using AutoMapper;
using HotelManagementSystem.Data;
using HotelManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Helpers
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<GuestVM, Guest>();
              
               
            CreateMap<RoomStore, RoomStoreVM>().ReverseMap();
            CreateMap<SuperAdmin, SuperAdminVM>().ReverseMap();
            CreateMap<Staff, StaffVM>().ReverseMap();

            
        }
    }
}
