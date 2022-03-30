using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace quanLyGiay.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CatId { get; set; }
        
        [Required]
        public String Name { get; set; }

        [Required]
        public string Detail { get; set; }
        

        public string Img { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public DateTime? Create_At { get; set; }

        public DateTime? Updated_At { get; set; }

        public int Status { get; set; }

    }
}