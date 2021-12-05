
using HotelManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelManagementSystem.DTO
{
    public class GuestVM 
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string PhoneNo { get; set; }
 
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }


      
       

        
    }
}
