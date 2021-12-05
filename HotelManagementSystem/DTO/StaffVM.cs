
using HotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelManagementSystem.DTO
{
    public class StaffVM 
    {
        [Required]
        public long Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
