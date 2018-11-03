using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC体验.Models;

namespace MVC体验.Controllers.C02
{
    public class C02ViewTypeController : Controller
    {
        #region 1.0  弱类型视图

        public ActionResult Index()
        {
            return View(new Pig() { Name = "小猪", Age = 1 });
        }

        #endregion

        #region 2.0 强类型视图

        public ActionResult Index1()
        {
            return View(new Pig() { Name = "小猪", Age = 1 });
        }

        #endregion

    }
}
