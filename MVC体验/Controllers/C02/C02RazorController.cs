using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C02
{
    using System.Web.WebPages;              //引用该命名空间后，就可以使用IsInt()和AsInt()方法了

    /// <summary>
    /// Razor语法
    /// </summary>
    public class C06RazorController : Controller
    {
        //
        // GET: /C06Razor/
        public ActionResult Index(string str)
        {
            if (str.IsInt() == false)
            {
                //todo：提示参数不合法
            }

            return View();
        }

    }
}
