using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{
    public class Booking: EntityBase
    {

        public string? Room { get; set; }

        public DateTime CheckIn { get; set; }

        public virtual Guest Guests { get; set; }
        public bool Completed { get; set; }
       
      

       

    }
}
