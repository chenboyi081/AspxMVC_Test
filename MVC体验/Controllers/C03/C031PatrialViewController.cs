using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C03
{
    public class C031PatrialViewController : Controller
    {
        //
        // GET: /C01PatrialView/

        public ActionResult Index()
        {
            //return View(); :先运行_ViewStart.cshtml 再执行视图中的内容
            return PartialView();
        }

        public ActionResult CallPartialView()
        {
            return View();
        }

    }
}
