using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{

    [Table(nameof(Guest))]
    public class Guest : EntityBase
    {
        public Guest()
        {
        }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public ICollection<Booking>  Bookings { get; set; }
        public string PhoneNo { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

    }
}
