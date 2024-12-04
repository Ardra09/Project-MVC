using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_mvcasp.Models;
namespace Project_mvcasp.Controllers
{
    public class CompanyRegController : Controller
    {
        MVCProjectEntities2 db = new MVCProjectEntities2();
        // GET: CompanyReg
        public ActionResult Insert_Pageload()
        {
            return View();
        }
        public ActionResult InsertComp_Click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = db.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                //get
                db.sp_CompanyReg(regid, clsobj.name, clsobj.email, clsobj.phone, clsobj.location, clsobj.website);
                db.sp_LoginInsert(regid, clsobj.username, clsobj.pwd, "Company");
                clsobj.adminmsg = "Successfully Inserted";
                return View("Insert_PageLoad", clsobj);
            }
            return View("Insert_PageLoad", clsobj);
        }
    }
}