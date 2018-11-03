using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C02
{
    public class C02SessionController : Controller
    {
        /// <summary>
        /// 在get请求的时候设置一个session["uname"]="admin"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            Session["uname"] = "admin";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string uanmefromsesson = Session["uname"].ToString();
            return Content(uanmefromsesson);
        }
    }
}
