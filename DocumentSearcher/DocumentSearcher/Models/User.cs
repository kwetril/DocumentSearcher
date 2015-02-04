using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]

        public string Password { get; set; }
        [Display(Name = "Password")]
        public string PasswordSalt { get; set; }
    }
}