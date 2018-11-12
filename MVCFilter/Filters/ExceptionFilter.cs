using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Filters
{
    /// <summary>
    /// 错误捕获过滤器自定义类
    /// </summary>
    public class ExceptionFilter :HandleErrorAttribute
    {
        /// <summary>
        /// 当action中发生了未捕获的异常，则有MVC框架自动调用此方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            //获取当前action发生的异常对象
            Exception ex = filterContext.Exception;
            //TODO:将详细异常信息写入到文本或者数据库

            //告诉MVC框架，我已经处理完毕异常，你不需要处理
            filterContext.ExceptionHandled = false;

            base.OnException(filterContext);
        }
    }
}
