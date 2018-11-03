using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers
{
    public class C02ActionResultSubClassController : Controller
    {
        #region 1.0 ContentResult 用于返回一个字符串,没有视图对应

        public ActionResult ContentResultDemo()
        {
            //return Content(DateTime.Now.ToString());  //相当于 Response.Write(DateTime.Now.ToString());
            return Content("<script>alert('OK')</script>");
        }

        #endregion

        #region 2.0  EmptyResult 返回一个空的结果，仅仅只是一个占位，没有实际意义

        public ActionResult EmptyResultDemo()
        {
            return new EmptyResult(); //占位
        }


        #endregion

        #region 3.0 FileResult 实现一个验证码 (常用)

        public ActionResult FileResultDemo()
        {
            //1.0 构造一个位图
            #region 1.0 验证码的第一种形式
            //using (Image img = new Bitmap(65, 25))
            //{
            //    using (Graphics g = Graphics.FromImage(img))
            //    {
            //        //清除位图背景
            //        g.Clear(Color.White);

            //        //画边框
            //        g.DrawRectangle(Pens.Blue, 0, 0, img.Width - 1, img.Height - 1);

            //        //画验证码
            //        string vcode = "123a";
            //        g.DrawString(vcode, new Font("黑体", 16
            //            , FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout)
            //            , new SolidBrush(Color.Red)
            //            , 0, 0);
            //    }
            //    Response.ContentType = "image/jpeg"; //告诉浏览器解析的是图片
            //    img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //} 
            #endregion
            //Response.ContentType = "image/jpeg";
            //Response.OutputStream
            //return File();

            #region 2.0 利用FileResult的形式将验证码响应回去（MVC中推荐使用）
            byte[] imgbuffer = null;

            using (Image img = new Bitmap(65, 25))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    //清除位图背景
                    g.Clear(Color.White);

                    //画边框
                    g.DrawRectangle(Pens.Blue, 0, 0, img.Width - 1, img.Height - 1);

                    //画验证码
                    string vcode = "123a";
                    g.DrawString(vcode, new Font("黑体", 16
                        , FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout)
                        , new SolidBrush(Color.Red)
                        , 0, 0);
                }

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {

                    //将图片保存到了内存流对象ms中
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //将ms流中的数据转换成byte[]数组
                    imgbuffer = ms.ToArray();
                }

            }
            #endregion
            //利用FileResult子类将图片响应回浏览器
            return File(imgbuffer, "image/jpeg");
        }

        #endregion

        #region 4.0 JsonResult  实现将对象自动转换成json字符串 (常用)

        public ActionResult JsonResultDemo()
        {
            //注意点：如果是get请求，则要将JsonRequestBehavior设置成AllowGet
            return Json(new { Name = "八戒", Age = 500 }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 5.0 HttpStatusCodeResult 手工修改响应的状态码为指定的数值

        public ActionResult HttpStatusCodeResultDemo()
        {
            //Response.StatusCode //200:ok
            //return new HttpStatusCodeResult(404); // 资源没有找到
            return new HttpStatusCodeResult(500); //服务器异常
        }

        #endregion

        #region 6.0 JavaScriptResult 返回一段js脚本,配合ajax使用

        public ActionResult ViewResultDemo()
        {
            return View();
        }

        public ActionResult JavaScriptResultDemo()
        {
            return JavaScript("alert('我被执行了')");
        }

        #endregion

        #region 7.0 RedirectResult 页面跳转演示 （常用）

        public ActionResult RedirectResultDemo()
        {
            return Redirect("/C02ActionResultSubClass/ViewResultDemo");
        }

        #endregion

        #region 8.0 RedirectToRouteResult 根据路由参数进行页面跳转 （常用）

        public ActionResult RedirectToRouteResultDemo()
        {
            //RedirectToRoute（）中的参数可以使用匿名类代替，其中的属性名称一定要和路由规则中的{}中的名称保持一致,根据程序员指定的参数根据路由规则自动生成匹配的 url
            return RedirectToRoute(new { controller = "GroupInfo", action = "Index", id = 100 });
        }
        #endregion

    }
}
