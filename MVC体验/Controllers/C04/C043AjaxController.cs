using MVC体验.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C04
{
    public class C043AjaxController : Controller
    {
        //
        // GET: /C043Ajax/

        #region 使用Ajax.ActionLink()的操作
      
       
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetTime()
        //{
        //    System.Threading.Thread.Sleep(2000);

        //    return Content(DateTime.Now.ToString());
        //}

        /// <summary>
        /// 被ajax请求的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTime()
        {
            System.Threading.Thread.Sleep(2000);
            //格式：{"time":"2014-8-4 12:00:00"}
            return Json(new { time = DateTime.Now.ToString() }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 2.0 演示@Ajax.BeginForm()的ajax操作

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Dog dog)
        {
            //TODO:执行新增逻辑代码
            //以json格式将提醒数据返回
            return Json(new { status = 0, msg = "新增成功" });
        }

        #endregion


    }
}
