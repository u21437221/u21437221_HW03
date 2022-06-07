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

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string option)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    if (option == "option1")
                    {
                        string _path = Path.Combine(Server.MapPath("~/Media/Documents"), _FileName);
                        file.SaveAs(_path);
                    }
                    else if(option == "option2")
                    {
                        string _path = Path.Combine(Server.MapPath("~/Media/Images"), _FileName);
                        file.SaveAs(_path);
                    }
                    else if (option == "option3")
                    {
                        string _path = Path.Combine(Server.MapPath("~/Media/Videos"), _FileName);
                        file.SaveAs(_path);
                    }
                    
                }
                ViewBag.Message = "File uploaded successfully";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed";
                return View();
            }
        }

        public ActionResult About()
        {
            string[] picturefiles = Directory.GetFiles(Server.MapPath("~/MyPicture"));
            List<Models.PictureModel> picture = new List<Models.PictureModel>();
            foreach (string pictureFile in picturefiles)
            {
                picture.Add(new Models.PictureModel { Picture = Path.GetFileName(pictureFile) });
            }
            return View(picture);
        }
    }
}