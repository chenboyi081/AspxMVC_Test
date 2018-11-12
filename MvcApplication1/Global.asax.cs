using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 注意点，MVC自动生成的执行代码顺序不能改变
        /// </summary>
        protected void Application_Start()
        {
            //1.0 负责注册当前MVC网站中所有的区域路由规则
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //3.0 注册网站路由规则
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}