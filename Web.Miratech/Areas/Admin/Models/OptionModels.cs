using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Miratech.Areas.Admin.Models
{
    public class OptionModels
    {
        public int ID { get; set; }

        public bool SologanEnable { get; set; }

        public string SologanTitle { get; set; }

        public string SologanContent { get; set; }

        public bool BlockAreasEnable { get; set; }

        public bool WhoweareEnable { get; set; }

        public bool NewEnable { get; set; }

        public int ClientEnable { get; set; }
    }
}