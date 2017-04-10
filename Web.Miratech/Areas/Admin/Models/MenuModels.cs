using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Miratech.Models
{
    public class MenuModels
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public bool isDropdown { get; set; }

        public int ParentID { get; set; }

        public int? Order { get; set; }

        public bool Visible { get; set; }

        public bool ShowInView { get; set; }

        public string Target { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}