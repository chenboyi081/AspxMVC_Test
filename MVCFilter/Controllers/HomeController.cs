using MVCFilter.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Controllers
{
    [ActionFilterCust, AllowAnonymous]  //贴到控制器类上，表示此控制器中的所有action方法在执行的时候都要出发ActionFilterCust过滤器的所有重写方法
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [ActionFilterCust]
        public ActionResult Index(int id)
        {
            Response.Write("2、Ok<br />");
            return Content("5、OK1 <br />");
        }

        [HttpGet, ActionFilterCust]
        public ActionResult Add()
        {
            return View();
        }

    }
}
