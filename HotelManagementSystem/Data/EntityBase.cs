using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{
    public class EntityBase
    {
        [Key]
       public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
