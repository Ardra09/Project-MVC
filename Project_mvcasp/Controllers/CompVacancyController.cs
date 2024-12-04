using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_mvcasp.Models;
namespace Project_mvcasp.Controllers
{
    public class CompVacancyController : Controller
    {
        MVCProjectEntities2 dbobj = new MVCProjectEntities2();
        // GET: CompVacancy
        public ActionResult CompVacancy_Pageload()
        {
            return View();
        }
        public ActionResult CompanyVacancy(CompVacancy clsobj)
        {
            if (ModelState.IsValid)
            {
                int CompId = Convert.ToInt32(Session["usid"]);
                clsobj.cid = CompId;

                dbobj.sp_Company_Vaccancy(clsobj.cid, clsobj.jtitle, clsobj.jdesc, clsobj.skills, clsobj.exp, clsobj.loc, clsobj.srange, clsobj.jtype, clsobj.postdate, clsobj.lastdate, clsobj.status);
                clsobj.jmsg = "Successfully Inserted";
                return RedirectToAction("CompanyHome", "Login");
            }
            return RedirectToAction("CompanyHome", clsobj);
        }
    }
}