using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing.QrCode;
using ZXing.Common;
using ZXing;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Mime;

namespace nzw.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QRCodeEncoder(string str, int width = 226, int height = 226)
        {
            if (string.IsNullOrEmpty(str))
                return View();
            str = HttpUtility.UrlDecode(str);
            QRCodeWriter qRCodeWriter = new QRCodeWriter();
            BitMatrix bitMatrix = qRCodeWriter.encode(str, ZXing.BarcodeFormat.QR_CODE, width, height);
            BarcodeWriter barcodeWriter = new BarcodeWriter(); 
             Bitmap bitmap = barcodeWriter.Write(bitMatrix);
            Stream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);
            bitmap.Dispose();
            return File(stream, MimeMapping.GetMimeMapping(".gif"));
        }

        public ActionResult BarCodeEncoder(string str,int width=326,int height=126)
        {
            if (string.IsNullOrEmpty(str))
                return View();
            str = HttpUtility.UrlDecode(str);
            BarcodeWriter barCodeWriter = new BarcodeWriter();
            barCodeWriter.Format = BarcodeFormat.CODABAR;
            BitMatrix bitMatrix = new BitMatrix(width, height);
            bitMatrix= barCodeWriter.Encode(str);
            Bitmap bitmap= barCodeWriter.Write(bitMatrix);
            Stream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);
            bitmap.Dispose();
            return File(stream, MimeMapping.GetMimeMapping(".gif"));
        }
    }
}