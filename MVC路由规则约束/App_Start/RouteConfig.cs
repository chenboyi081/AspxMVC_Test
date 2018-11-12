using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC路由规则约束
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
                        * 特点：1、路由规则中的{controller}和{action}占位符的名字不能修改其他的
                        *  2、路由规则字面量的间隔符可以使用任意字符，但是不能没有分隔符，建议使用/的分隔符定义自己的路由规则
                        *  3、路由规则参数约束：约束匹配成功当前的规则的url的参数必须与路由规则参数的正则表达式匹配
                        *  4、路由规则命名空间约束:约束匹配成功当前的规则的url的控制器对象创建时，去指定的命名空间中查找
                        * 
                        */
            routes.MapRoute(
            name: "Default1",
            url: "itcast/{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            , constraints: new { id = "\\d+" } //约束此路由规则的id参数必须是一个数字
              );

            routes.MapRoute(
            name: "Default5",
            url: "itcast/{controller}/{action}/{id}/{name}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, name = UrlParameter.Optional }
            , constraints: new { id = "\\d+", name = "^a$" } //约束此路由规则的id参数必须是一个数字 ,name必须是一个a， 如果id和name只要有一个不匹配，则路由规则不会匹配成功
            , namespaces: new string[] { "Ctrl.Mamager2" }//告诉MVC DefaultControllerFactory 去指定的命名空间中查找控制器类，并且获取其Type类型后创建其对象实例存入上下文的ramaphander中
              );

            routes.MapRoute(
             name: "Default2",
             url: "{controller}-{action}-{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}