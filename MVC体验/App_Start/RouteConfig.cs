using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC体验
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default", //路由规则在RouteCollection集合中的key,多条路由规则的名字不能重复
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "GroupInfo"  //url路由规则中{controller}的默认数据
                    ,
                    action = "Index"  //url路由规则中{action}的默认数据
                    ,
                    id = UrlParameter.Optional //id为可选参数
                }
            );
        }
    }
}