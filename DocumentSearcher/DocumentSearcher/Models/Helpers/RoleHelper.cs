using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentSearcher.Models.Helpers
{
    public static class RoleHelper
    {
        public static string UserRole 
        {
            get
            {
                return "User";
            }
        }

        public static string AdminRole 
        {
            get
            {
                return "Admin";
            }
        }
    }
}