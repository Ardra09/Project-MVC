using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_mvcasp.Models
{
    public class CompanyInsert
    {
        [Required(ErrorMessage = "Enter the name")]
        public string name { set; get; }
        [Required(ErrorMessage = "Enter valid email id")]
        public string email { set; get; }
        [Required(ErrorMessage = "Enter the phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { set; get; }
        public string location { set; get; }
        public string website { set; get; }
        public string username { set; get; }
        public string pwd { set; get; }
        [Compare("pwd", ErrorMessage = "Password mismatch")]
        public string conpwd { set; get; }
        public string adminmsg { set; get; }
    }
}