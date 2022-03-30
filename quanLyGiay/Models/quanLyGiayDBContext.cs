using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace quanLyGiay.Models
{
    public class quanLyGiayDBContext:DbContext
    {
        public quanLyGiayDBContext() : base("name=ChuoiKN")
        {
            
        }

        public DbSet<Category> Categories { get; set; }

       
        public DbSet<Order> Orders{ get; set; }

        public DbSet<Orderdetail> Orderdetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }



    }
}