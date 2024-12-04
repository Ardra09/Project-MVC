using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Project_mvcasp.Models;
namespace Project_mvcasp.Controllers
{
    public class SearchJobController : Controller
    {
        MVCProjectEntities2 dbobj = new MVCProjectEntities2();
        // GET: SearchJob
        public ActionResult searchjob_Pageload()
        {
            return View(GetData());
        }
        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.CompanyVacancy_tab.ToList();
           foreach(var e in job)
            {
                var jobcls = new jsearch();
                jobcls.job_Id = e.Job_Id;
                jobcls.company_Id = e.Company_Id;
                jobcls.skills = e.Skills;
                jobcls.experience = e.Experience;
                jobcls.lastdate = e.Last_Date;
                jobcls.status = e.Status;
                joblist.selectjob.Add(jobcls);
                var s = jobcls.skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }
        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += "and Skills like '%" + clsobj.insertse.skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.experience))
            {
                qry += "and Experience like '%" + clsobj.insertse.experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.loc))
            {
                qry += "and Location like '%" + clsobj.insertse.loc + "%'";
            }
            return View("searchjob_Pageload", getdata1(clsobj, qry));
        }
        private JobSearch getdata1(JobSearch clsobj, string qry)
        {
             using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while(dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.company_Id = Convert.ToInt32(dr["Company_Id"].ToString());
                    jobcls.skills = dr["Skills"].ToString();
                    jobcls.experience = dr["Experience"].ToString();
                    if (dr["Last_Date"] != DBNull.Value)
                    {
                        jobcls.lastdate = Convert.ToDateTime(dr["Last_Date"]);
                    }
                    jobcls.status = dr["Status"].ToString();
                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}