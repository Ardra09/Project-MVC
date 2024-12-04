using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_mvcasp.Models
{
    public class CompVacancy
    {
        [Required(ErrorMessage = "Enter Id")]
        public int cid { set; get; }
        [Required(ErrorMessage = "Enter Job Title")]
        public string jtitle { set; get; }
        [Required(ErrorMessage = "Enter Job Description")]
        public string jdesc { set; get; }
        public string skills { set; get; }
        public string exp { set; get; }
        public string loc { set; get; }
        public string srange { set; get; }
        public string jtype { set; get; }
        public DateTime postdate { set; get; }
        public DateTime lastdate { set; get; }
        public string status { set; get; }
        public string jmsg { set; get; }
    }
}