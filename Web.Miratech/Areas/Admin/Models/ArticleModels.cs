using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Miratech.Models
{
    public class ArticleModels
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public int UserID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Describe { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public string Image { get; set; }

        public bool Visible { get; set; }

        public bool Enable { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? LastEditUser { get; set; }

        public DateTime? LastEditTime { get; set; }

    }
}