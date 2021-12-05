
using HotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.DTO
{
    public class RoomStoreVM 
    {
        public long Id { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string RoomNo { get; set; }
        [StringLength(200)]
        public string Picture { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
