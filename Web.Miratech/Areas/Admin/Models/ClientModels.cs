using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Miratech.Models
{
    public class ClientModels
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Infomation { get; set; }

        public string Order { get; set; }

        public bool Visible { get; set; }
    }
}