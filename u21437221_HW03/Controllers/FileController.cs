using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21437221_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult FileIndex()
        {
            //Get the files from the subfolder and store in array
            string[] folderFiles = Directory.GetFiles(Server.MapPath("~/Media/Documents"));
            List<Models.FileModel> file = new List<Models.FileModel>();
            //Store the documents in the list
            foreach (string folderFile in folderFiles)
            {
                file.Add(new Models.FileModel { FileName = Path.GetFileName(folderFile) });
            }
            return View(file);
        }

        public FileResult DownloadFile(string Name)
        {
            //Get the document name and location
            string fileDestination = Server.MapPath("~/Media/Documents/") + Name;
            byte[] array = System.IO.File.ReadAllBytes(fileDestination); 
            //Downloads the document to the computer
            return File(array, "application/octet-stream", Name);
        }

        public ActionResult DeleteFile(string Name)
        {
            //Gets the document name and location
            string fullFile = Request.MapPath("~/Media/Documents/" + Name);
            if (System.IO.File.Exists(fullFile))
            {
                //Deletes the document from the subfolder
                System.IO.File.Delete(fullFile);
                ViewBag.deleteSuccess = "true";
            }
            return RedirectToAction("FileIndex");
        }
    }
}