using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21437221_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult VideoIndex()
        {
            string[] videoFiles = Directory.GetFiles(Server.MapPath("~/Media/Videos"));
            List<Models.FileModel> video = new List<Models.FileModel>();
            foreach (string videoFile in videoFiles)
            {
                video.Add(new Models.FileModel { FileName = Path.GetFileName(videoFile) });
            }
            return View(video);
        }

        public FileResult DownloadFile(string Name)
        {
            string fileDestination = Server.MapPath("~/Media/Videos/") + Name;
            byte[] array = System.IO.File.ReadAllBytes(fileDestination);
            return File(array, "application/octet-stream", Name);
        }

        public ActionResult DeleteFile(string Name)
        {
            string fullFile = Request.MapPath("~/Media/Videos/" + Name);
            if (System.IO.File.Exists(fullFile))
            {
                System.IO.File.Delete(fullFile);
                ViewBag.deleteSuccess = "true";
            }
            return RedirectToAction("VideoIndex");
        }
    }
}