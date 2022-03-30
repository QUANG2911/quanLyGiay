using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanLyGiay.Models
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public DateTime? Create_At { get; set; }

        public DateTime? Updated_At { get; set; }

        public int Status { get; set; }

    }
}