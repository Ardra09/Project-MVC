using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_mvcasp.Models;
namespace Project_mvcasp.Controllers
{
    public class UserApplyController : Controller
    {
        MVCProjectEntities2 dbobj = new MVCProjectEntities2();
        // GET: UserApply
        public ActionResult UserApplication_Pageload()
        {
            return View();
        }

        public ActionResult SubmitUserApplication(UserApplication clsobj, HttpPostedFileBase file, int jid)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    //photo
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Resume", fname);
                    clsobj.resume = fullpath; //set  
                }
                int UserId = Convert.ToInt32(Session["usid"]);
                clsobj.uid = UserId;
                clsobj.jid = jid;

                dbobj.sp_UserApplication(clsobj.jid, clsobj.uid, clsobj.applndate, clsobj.resume, "Applied");
                clsobj.msg = "Successfully Applied";
                return RedirectToAction("UserApplication_Pageload");
            }
            return RedirectToAction("UserApplication_Pageload", clsobj);
        }
    }
}