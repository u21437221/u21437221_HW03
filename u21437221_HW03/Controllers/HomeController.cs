using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21437221_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            string _FileName = Path.GetFileName(file.FileName);
        //            string _path = Path.Combine(Server.MapPath("~/Media"), _FileName);
        //            file.SaveAs(_path);
        //        }
        //        ViewBag.Message = "File uploaded successfully";
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "File upload failed";
        //        return View();
        //    }
        //}

        public ActionResult About()
        {
            return View();
        }
    }
}