using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_mvcasp.Models;
namespace Project_mvcasp.Controllers
{
    public class UserRegController : Controller
    {
        MVCProjectEntities2 dbobj = new MVCProjectEntities2();
        // GET: UserReg
        public ActionResult InsertUser_pageload()
        {
            return View();
        }
        public ActionResult Insert_click(UserInsert clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photo/");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\Photo", fname);
                    clsobj.photo = fullpath;
                }
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
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
                dbobj.sp_UserReg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.phone, clsobj.location, clsobj.gender, clsobj.qualification, clsobj.skills, clsobj.experience, clsobj.photo);
                dbobj.sp_LoginInsert(regid, clsobj.username, clsobj.password, "user");
                clsobj.usermsg = "Succesfully Inserted";
                return View("InsertUser_pageload", clsobj);
            }
            return View("InsertUser_pageload", clsobj);
        }
    }
}