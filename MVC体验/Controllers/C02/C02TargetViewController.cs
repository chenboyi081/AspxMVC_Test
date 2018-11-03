using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C02
{
    public class C02TargetViewController : Controller
    {
        //
        // GET: /C04TargetView/

        public ActionResult Index()
        {
            //负责返回默认视图
            //return View();

            //返回和当前控制器同名的文件夹下的IndexForIpad.cshtml视图
            //return View("IndexForIpad");

            return View("/Views/C02GetPostPamrs/PostParmsView.cshtml");
        }

    }
}
