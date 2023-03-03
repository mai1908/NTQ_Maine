using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maine.Areas.Admin.Models
{
    public class LoginModel
    {
        internal string UserName;

        [Required(ErrorMessage ="Mời nhập user name")]
        public string LoginProvider { get; set; }

        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}