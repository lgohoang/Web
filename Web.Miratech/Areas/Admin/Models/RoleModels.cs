using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Miratech.Models
{
    public class RoleModels
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Detail { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}