using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanLyGiay.Models
{
    [Table(" Orderdetails")]
    public class Orderdetail
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
       
        public int UserId { get; set; }
       
        public int ProductId { get; set; }

        public double Price{ get; set; }

        public int Tong { get; set; }

        public double Amount { get; set; }

        public int? Status { get; set; }
    }
}