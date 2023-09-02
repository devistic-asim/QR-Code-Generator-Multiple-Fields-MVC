using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace QRCode_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Label Input";
            return View();
        }

        //temp
        public ActionResult temp()
        {
            ViewBag.Title = "Label Input";
            return View();
        }


        [HttpPost]
        public ActionResult Label(string qrcode)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    ViewBag.Title = "Label Print";
                }
            }
            return View();
        }
    }
}