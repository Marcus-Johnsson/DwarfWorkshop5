using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DwarfWorkshop5.Models
{
    internal class MyDbContext : DbContext
    { 
        
        public DbSet<Dwarfs> Dwarfs { get; set; } 
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Products> Products { get; set; }

       
      
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<WorkOrder> WorkOrder { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DwarfWorkShop;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
