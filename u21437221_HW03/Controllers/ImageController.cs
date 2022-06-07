using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21437221_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult ImageIndex()
        {
            string[] imageFiles = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            List<Models.FileModel> image = new List<Models.FileModel>();
            foreach (string imageFile in imageFiles)
            {
                image.Add(new Models.FileModel { FileName = Path.GetFileName(imageFile) });
            }
            return View(image);
        }

        public FileResult DownloadFile(string Name)
        {
            string fileDestination = Server.MapPath("~/Media/Images/") + Name;
            byte[] array = System.IO.File.ReadAllBytes(fileDestination);
            return File(array, "application/octet-stream", Name);
        }

        public ActionResult DeleteFile(string Name)
        {
            string fullFile = Request.MapPath("~/Media/Images/" + Name);
            if (System.IO.File.Exists(fullFile))
            {
                System.IO.File.Delete(fullFile);
                ViewBag.deleteSuccess = "true";
            }
            return RedirectToAction("ImageIndex");
        }
    }
}