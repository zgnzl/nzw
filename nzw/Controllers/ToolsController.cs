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
using System.Runtime.Remoting;

namespace nzw.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QRCodeEncoder(string str,int barcode= 2048, int width = 226, int height = 226)
        {
            if (string.IsNullOrEmpty(str))
                return View();
            str = HttpUtility.UrlDecode(str);
            string typename = ((_BarcodeFormat)barcode).ToString().Replace("_",".");
            ObjectHandle handle = Activator.CreateInstance("zxing", "ZXing." +typename);
            dynamic qRCodeWriter = handle.Unwrap();
            BitMatrix bitMatrix = qRCodeWriter.encode(str, (BarcodeFormat)barcode, width, height);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap bitmap = barcodeWriter.Write(bitMatrix);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);
            bitmap.Dispose();
            return File(stream.ToArray(), MimeMapping.GetMimeMapping(".gif"));
        }

        
        public ActionResult QRCodeDncoder()
        {
            return Content("此功能即将上线");
        }

        public ActionResult UrlEncoder(string str)
        {
            return Content("此功能即将上线");
        }

        public ActionResult UrlDncoder(string str)
        {
            return Content("此功能即将上线");
        }

        public ActionResult JsonFormat(string str)
        {
            return Content("此功能即将上线");
        }

        public ActionResult AddWaterMark()
        {
            return Content("此功能即将上线");
        }
    }
    public enum _BarcodeFormat
    {
        //
        // 摘要:
        //     Aztec 2D barcode format.
        Aztec_AztecWriter = 1,

        //
        // 摘要:
        //     Data Matrix 2D barcode format.
        Datamatrix_DataMatrixWriter = 32,
        //
        // 摘要:
        //     PDF417 format.
        PDF417_PDF417Writer = 1024,
        //
        // 摘要:
        //     QR Code 2D barcode format.
        QrCode_QRCodeWriter = 2048,
    }
}