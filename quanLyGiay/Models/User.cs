using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanLyGiay.Models
{
    [Table(" Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password{ get; set; }

        public DateTime? Create_At { get; set; }

        public DateTime? Updated_At { get; set; }

    }
}