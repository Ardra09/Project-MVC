using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_mvcasp.Models
{
    public class UserInsert
    {
        [Required(ErrorMessage = "Enter Name")]
        public string name { set; get; }
        [Range(18, 50, ErrorMessage = "Enter Age")]
        public int age { set; get; }
        [Required(ErrorMessage = "Enter Address")]
        public string address { set; get; }
        [EmailAddress(ErrorMessage = "Enter valid email Id")]
        public string email { set; get; }
        [Required(ErrorMessage = "Enter the phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { set; get; }
        public string location { set; get; }
        public string gender { set; get; }
        public string qualification { set; get; }
        public string skills { set; get; }
        public int experience { set; get; }
        public string photo { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        [Compare("password", ErrorMessage = "Password Mismatch")]
        public string confirmpassword { set; get; }
        public string usermsg { set; get; }
    }
}