using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC体验.Models;

namespace MVC体验.Controllers.C03
{
    /// <summary>
    ///  负责演示模型注解和验证的控制器
    /// </summary>
    public class C032ZJController : Controller
    {
        //
        // GET: /C032ZJ/

        [HttpGet]
        public ActionResult Add()
        {
            Person per = new Person() { Name = "八一", Age = 500 };
            return View(per);
        }

        [HttpPost]
        public ActionResult Add(Person model)
        {
            //验证model参数中的属性值是否全部合法
            if (ModelState.IsValid == false)
            {
                return View();
            }
            return new EmptyResult();
        }

        /// <summary>
        /// 负责检查猪的名字是否已经存在，此方法被ajax请求
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckName()
        {
            //1.0 获取当前要检查的名称值
            string name = Request.Form["Name"];

            if (name == "八一")
            {
                //当name的值等于八一，则告诉用户此用户名已经使用
                return Content("false");
            }
            else
            {
                //表示此用户名可以使用
                return Content("true");
            }
        }
    }
}
