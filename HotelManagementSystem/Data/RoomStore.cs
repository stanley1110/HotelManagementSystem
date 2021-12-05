using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{
    [Table(nameof(RoomStore))]
    public class RoomStore : EntityBase
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public bool Available { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [StringLength(200)]
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
