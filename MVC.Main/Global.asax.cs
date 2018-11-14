using Plugs.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Main
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //告诉MCV框架使用PlugsControllerFactory替换DefaultControllerFactory来运行
            ControllerBuilder.Current.SetControllerFactory(new PlugsControllerFactory());

            //将当前系统中的aspx视图引擎移除(优化)
            //ViewEngines.Engines.RemoveAt(0);

            //移除当前MVC中的aspx和Razor引擎
            ViewEngines.Engines.Clear();

            //将插件的视图引擎加载的MVC中执行
            ViewEngines.Engines.Add(new PlugsRazorViewEnginee());
        }
    }
}