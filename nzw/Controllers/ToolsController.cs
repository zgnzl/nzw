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
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace nzw.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QRCodeEncoder(string str, int barcode = 2048, int width = 226, int height = 226)
        {
            if (string.IsNullOrEmpty(str))
                return View();
            str = HttpUtility.UrlDecode(str);
            string typename = ((_BarcodeFormat)barcode).ToString().Replace("_", ".");
            ObjectHandle handle = Activator.CreateInstance("zxing", "ZXing." + typename);
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

        public ActionResult UrlEncoder()
        {
            return View();
        }

        public ActionResult UrlDncoder(string str)
        {
            return Content("此功能即将上线");
        }

        public ActionResult JsonFormat()
        {
            return View();
        }

        public ActionResult AddWaterMark()
        {
            return Content("此功能即将上线");
        }

        public ActionResult IPSource(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                 ip = Request.ServerVariables["http_x_forwarded_for"];
                if (string.IsNullOrEmpty(ip)) ip = Request.ServerVariables["remote_addr"];
                else//代理ip地址有内容，判断是否符合ipv4地址或者是否为内网地址
                {
                    ip = ip.Trim().Replace(" ", "");
                    if (!Regex.IsMatch(ip, @"^\d+(\.\d+){3}$") || IsPrivateIp(ip))
                        ip = Request.ServerVariables["remote_addr"];//不符合规则或者内网/私有地址使用remote_addr代替
                }
                ViewBag.ip =ip== "::1" ? "127.0.0.1" : ip;
            }
            return View();
        }
        private static bool IsPrivateIp(string ip)
        {
            long ABegin = IpToNumber("10.0.0.0"), AEnd = IpToNumber("10.255.255.255"),//A类私有IP地址
             BBegin = IpToNumber("172.16.0.0"), BEnd = IpToNumber("172.31.255.255"),//'B类私有IP地址
             CBegin = IpToNumber("192.168.0.0"), CEnd = IpToNumber("192.168.255.255"),//'C类私有IP地址
             IpNum = IpToNumber(ip);
            return (ABegin <= IpNum && IpNum <= AEnd) || (BBegin <= IpNum && IpNum <= BEnd) || (CBegin <= IpNum && IpNum <= CEnd);
        }

        private static long IpToNumber(string ip)
        {
            string[] arr = ip.Split('.');
            return 256 * 256 * 256 * long.Parse(arr[0]) + 256 * 256 * long.Parse(arr[1]) + 256 * long.Parse(arr[2]) + long.Parse(arr[3]);
        }

        public ActionResult EnCrypt(string str,string format="X")
        {
            if (string.IsNullOrEmpty(str))
                return View();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString(format);
            }
            return Content(byte2String);
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