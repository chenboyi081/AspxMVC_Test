using MVC.Site第二套demo.Attrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Site第二套demo.Filters
{
    /// <summary>
    /// 登录验证过滤器
    /// </summary>
    public class LoginCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //判断如果触发当前OnActionExecuting方法的action贴有SkipLogin则跳过登录检查
            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipLoginAttribute), false))
            {
                //阻断此方法中的下面的代码运行
                return;
            }

            //判断当前action所在的控制器是否贴有[SkipLogin]
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipLoginAttribute), false))
            {
                //阻断此方法中的下面的代码运行
                return;
            }

            //1.0 判断session["uinfo"]如果为null则调回到登录页面
            if (filterContext.HttpContext.Session["uinfo"] == null)
            {
                //2.0 跳转到登录页面
                // filterContext.HttpContext.Response.Redirect("/login/login");

                //2.0.1 直接修改返回视图跳转到登录页面，但是URL的路径还是停留在原始的url

                //ViewResult view = new ViewResult();
                //view.ViewName = "/Views/login/login.cshtml";//new UrlHelper(filterContext.RequestContext).Action("login", "login");
                //filterContext.Result = view;

                //2.0.2  只能被浏览器请求来调用
                if (filterContext.HttpContext.Request.IsAjaxRequest() == false)
                {
                    ContentResult cview = new ContentResult();
                    cview.Content = "<script>alert('您的登录信息失效，请重新登录');window.location='/login/login'</script>";
                    filterContext.Result = cview;
                }
                else
                {
                    JsonResult jsonView = new JsonResult();
                    jsonView.ContentType = "application/json";
                    jsonView.Data = new { status = 2, msg = "您的登录信息失效，请重新登录" };
                    jsonView.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                    filterContext.Result = jsonView;
                }
            }
        }

    }
}