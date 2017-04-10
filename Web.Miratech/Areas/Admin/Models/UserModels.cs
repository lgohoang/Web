using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Miratech.Models
{
    public class UserModels
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public string FullName { get; set; }

        public DateTime? CreateTime { get; set; }

        public bool Enable { get; set; }
    }
}