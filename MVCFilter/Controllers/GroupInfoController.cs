using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Controllers
{
    public class GroupInfoController : Controller
    {
        //
        // GET: /GroupInfo/

        public ActionResult Index()
        {
            int i = 0;
            int j = 1;
            int c = j / i; //抛出尝试除以0的错误

            return Content("GroupInfo .index");
        }

    }
}
