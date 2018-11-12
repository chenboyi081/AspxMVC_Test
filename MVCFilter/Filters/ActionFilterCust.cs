using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Filters
{
    /// <summary>
    /// 自定义方法过滤器类
    /// </summary>
    public class ActionFilterCust : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("1 、这是OnActionExecuting---输出的内容<br />");
            //filterContext.HttpContext.Session
            //1.0 获取当前过滤器的方法是由哪个action方法触发的(获取actin名称)
            string actionName = filterContext.ActionDescriptor.ActionName;
            filterContext.HttpContext.Response.Write("actionName=" + actionName + "<br />");
            //2.0 获取当前action所在的控制器名称
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //3.0 判断当前action是否贴有[HttpGet]属性
            bool isTrue = filterContext.ActionDescriptor.IsDefined(typeof(HttpGetAttribute), false);
            filterContext.HttpContext.Response.Write("IsDefined(typeof(HttpGetAttribute))=" + isTrue + "<br />");

            //4.0 获取当前action方法上贴有的[HttpGet]的对象实例
            object[] httpgets = filterContext.ActionDescriptor.GetCustomAttributes(typeof(HttpGetAttribute), false);
            if (httpgets != null && httpgets.Any())
            {
                HttpGetAttribute intance = httpgets[0] as HttpGetAttribute;
            }

            //5.0 记录当前方法的实际参数,2014-8-5 16:35:20 控制器/方法,参数1=参数1值,参数2=参数2值
            var dic = filterContext.ActionParameters;

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("3、这是OnActionExecuted---输出的内容<br />");
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("4、这是OnResultExecuting---输出的内容<br />");

            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("6、这是OnResultExecuted---输出的内容<br />");
            base.OnResultExecuted(filterContext);
        }
    }
}