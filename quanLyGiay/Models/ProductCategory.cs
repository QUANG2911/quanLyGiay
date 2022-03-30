using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanLyGiay.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public int CatId { get; set; }

        public String Name { get; set; }

        public string Detail { get; set; }

        public string Img { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public DateTime? Create_At { get; set; }

        public DateTime? Updated_At { get; set; }

        public int Status { get; set; }

        public string CatName { get; set; }

    }
}