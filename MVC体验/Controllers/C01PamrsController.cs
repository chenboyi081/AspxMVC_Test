using MVC体验.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers
{
    public class C01PamrsController : Controller
    {
        //
        // GET: /C01Pamrs/
        public ActionResult Index()
        {
            #region 1.0 ViewData[]来传递

            ViewData["Name"] = "八戒";

            #endregion

            #region 2.0 ViewBag 来传递 ,本质上是通过ViewData[]来传递的,
            //动态类型
            ViewBag.Age = 500; //等价于 ViewData["Age"]=500;
            ViewBag.Name = "唐僧"; //ViewData["Name"]="唐僧"
            #endregion

            #region 3.0 TempData[] 来传递

            TempData["isKill"] = true;

            #endregion

            //4.0 通过View（）方法将对象传递给视图中的Model
            return View(new Pig() { Name = "老猪", Age = 2 });
        }

    }
}
