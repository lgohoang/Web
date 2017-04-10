using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Miratech.Models
{
    public class ChangePasswordModels
    {
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Display(Name = "Re New Password")]
        public string ReNewPassword { get; set; }
    }
}