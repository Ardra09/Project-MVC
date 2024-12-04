using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_mvcasp.Models
{
    public class UserApplication
    {
        public int jid { set; get; }
        public int uid { set; get; }
        [Required(ErrorMessage = "Enter the Application Date")]
        public DateTime applndate { set; get; }
        public string resume { set; get; }
        public string status { set; get; }
        public string msg { set; get; }
    }
}