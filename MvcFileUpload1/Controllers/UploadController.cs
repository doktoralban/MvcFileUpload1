using System.IO;
using System.Web;
using System.Web.Mvc; 
using System.Linq;

namespace MvcFileUpload1.Controllers
{
    public class UploadController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".gif", ".jpeg", ".doc", ".docx", ".xls", ".xlsx", ".pdf" };
                var checkextension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(checkextension) || (file.ContentLength > 5500000))
                {
                    ViewBag.Message = "Eklenecek dosya .doc, .docx,.xls,.xlsx,.pdf .jpeg,.jpg, .png ya da .gif dosyaları olmalı ve 5MB'ı geçmemelidir.";

               
                    return View();
                }
                //......................................

                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                } 
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }




    }
}