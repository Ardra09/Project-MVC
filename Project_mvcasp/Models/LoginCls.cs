using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_mvcasp.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage = "Enter the Username")]
        public string uname { set; get; }
        [Required(ErrorMessage = "Enter the Password")]
        public string pswd { set; get; }
        public string msg { set; get; }
        public string ltype { set; get; }
    }
}