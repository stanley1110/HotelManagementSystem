
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {;
            //optionsBuilder.UseLazyLoadingProxies()
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<RoomStore>  RoomStores { get; set; }
        public virtual DbSet<Booking>  Bookings { get; set; }
        public virtual DbSet<Staff>  Staffs { get; set; }
        public virtual DbSet<SuperAdmin>  SuperAdmins { get; set; }
       
        }
    }

