using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_mvcasp.Models;
namespace Project_mvcasp.Controllers
{
    public class LoginController : Controller
    {
        MVCProjectEntities2 dbobj = new MVCProjectEntities2();
        // GET: Login
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult CompanyHome()
        {
            return View();
        }

        public ActionResult Login_Click(LoginCls clsobj)
        {
            var val = dbobj.sp_LoginCountId(clsobj.uname, clsobj.pswd).Single();
            if (val == 1)
            {
                var uid = dbobj.sp_LoginId(clsobj.uname, clsobj.pswd).FirstOrDefault();
                Session["usid"] = uid;
                var lt = dbobj.sp_LoginType(clsobj.uname, clsobj.pswd).FirstOrDefault();
                if (lt == "user")
                {
                    return RedirectToAction("UserHome");
                }
                else if (lt == "Company")
                {
                    return RedirectToAction("CompanyHome");
                }
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "Invalid Login";
                return View("Login_Pageload", clsobj);
            }
            return View("Login_Pageload", clsobj);
        }
    }
}