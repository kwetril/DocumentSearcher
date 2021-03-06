﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class User : IPrincipal
    {
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [StringLength(20)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                if (FirstName == null || LastName == null)
                {
                    return Login;
                }
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        [StringLength(10)]
        [Display(Name = "University group")]
        public string UniversityGroup { get; set; }

        public string Role {get; set; }

        public string PasswordSalt { get; set; }

        public IIdentity Identity
        {
            get 
            {
                return new GenericIdentity(Login);
            }
        }

        public bool IsInRole(string role)
        {
            return Role.Equals(role);
        }
    }
}