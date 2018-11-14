using MVC.Site第二套demo.Attrs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Site第二套demo.Controllers
{
    [SkipLogin]
    public class vcodeController : Controller
    {
        //
        // GET: /vcode/

        public ActionResult Vcode()
        {
            string vcode = "1234";

            //1.0 将验证码写入session
            Session["vcode"] = vcode;

            //2.0 将验证码画到图片上
            byte[] imgbuffer;
            using (Image img = new Bitmap(65, 25))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.White);

                    g.DrawRectangle(Pens.Red, 0, 0, img.Width - 1, img.Height - 1);

                    g.DrawString(vcode, new Font("黑体", 16, FontStyle.Bold), new SolidBrush(Color.Blue), 0, 0);

                }

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    imgbuffer = ms.ToArray();
                }
            }

            return File(imgbuffer, "image/jpeg");
        }

    }
}
