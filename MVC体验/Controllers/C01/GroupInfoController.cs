using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers
{
    /*
     * 为了程序员编程简单，MVC中有一系列控制器的约定：
     * 1、控制器的后缀必须是Controller ，并且要继承Controller父类
     * 2、控制器的方法要能够被浏览器请求，则一定是public
     * 3、视图是存在Views文件下的，一个action方法对应的视图文件位于 Views下的和当前控制器同名的文件下
     */
    public class GroupInfoController : Controller
    {
        // GET: /GroupInfo/
        public string Index()
        {
            return DateTime.Now.ToString();
        }

        public string IndexView()
        {
            return "<h1>我爱广州小蛮腰!!!</h1>";
        }

        /// <summary>
        /// 负责返回一个和IndexView1同名的视图
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexView1()
        {           
            //返回一个视图
            return View();
        }
    }
}
