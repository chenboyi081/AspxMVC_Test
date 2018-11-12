using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Filters
{
    /// <summary>
    /// 自定义过滤器类
    /// </summary>
    public class AuthorFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
            filterContext.HttpContext.Response.Write("0、这是OnAuthorization==输出的内容<br />");

            //base.OnAuthorization(filterContext); //统一进行form表单的登录验证失效，则必须自己实现
        }

    }
}
