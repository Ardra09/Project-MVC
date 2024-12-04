using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_mvcasp.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }
    }
    public class jsearch
    {
        public int job_Id { get; set; }
        public int company_Id { get; set; }
        public string jtitle { set; get; }
        public string jdesc { set; get; }
        public string skills { get; set; }
        public string experience { get; set; }
        public string loc { set; get; }
        public string srange { set; get; }
        public string jtype { set; get; }
        public DateTime postdate { set; get; }
        public DateTime lastdate { get; set; }
        public string status { get; set; }
        public string jobmsg { get; set; }
    }
}