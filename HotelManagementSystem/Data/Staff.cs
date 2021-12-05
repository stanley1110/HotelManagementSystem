using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{
    [Table(nameof(Staff))]
    public class Staff : EntityBase
    {

        
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }


        public string Gender { get; set; }

        public string ModifiedBy { get; set; }

        public string? ApprovalAdmin { get; set; }
        public string Username { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
