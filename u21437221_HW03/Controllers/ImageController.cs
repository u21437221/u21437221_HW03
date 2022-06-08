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
            //Get the images from the subfolder and store in array
            string[] imageFiles = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            List<Models.FileModel> image = new List<Models.FileModel>();
            //Store the images in the list
            foreach (string imageFile in imageFiles)
            {
                image.Add(new Models.FileModel { FileName = Path.GetFileName(imageFile) });
            }
            return View(image);
        }

        public FileResult DownloadFile(string Name)
        {
            //Get the image name and location
            string fileDestination = Server.MapPath("~/Media/Images/") + Name;
            byte[] array = System.IO.File.ReadAllBytes(fileDestination);
            //Downloads the images to the computer
            return File(array, "application/octet-stream", Name);
        }

        public ActionResult DeleteFile(string Name)
        {
            //Gets the image name and location
            string fullFile = Request.MapPath("~/Media/Images/" + Name);
            if (System.IO.File.Exists(fullFile))
            {
                //Deletes the image from the subfolder
                System.IO.File.Delete(fullFile);
                ViewBag.deleteSuccess = "true";
            }
            return RedirectToAction("ImageIndex");
        }
    }
}