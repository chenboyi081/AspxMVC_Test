using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C02
{
    public class C02GetPostPamrsController : Controller
    {
        #region 1.0 Url传参 ，一般适用于GET请求

        /// <summary>
        /// 浏览器访问此方法的url：http://localhost:12191/C02GetPostPamrs/UrlPamrs?id=1  可以通过
        /// Request.QueryString["id"]; 和Request.Params["id"];进行接收
        /// 
        ///  浏览器访问此方法的url：http://localhost:12191/C02GetPostPamrs/UrlPamrs/1/abc
        ///  可以通过在UrlPamrs方法中增加与路由规则{id}占位符同名的形参来接收
        ///  重要约定：方法的参数名字一定要和路由规则的占位符同名，才能接收到url传入的参数值
        ///  MVC底层，会自动根据方法的参数类型进行类型转成操作
        /// </summary>
        /// <returns></returns>
        public ActionResult UrlPamrs(string name, string id)
        {
            //获取参数的方式1
            string id2 = Request.QueryString["id"];
            string id1 = Request.Params["id"];

            //MVC推荐的方式
            return Content("参数id=" + id + "   ,id2=" + id2 + "  ,id1=" + id1 + "    ,name=" + name);
            //return Content("id2=" + id2 + "  ,id1=" + id1);
        }

        #endregion

        #region 2.0 请求报文体传参,一般用于Post请求

        [HttpGet] //作用：负责接收浏览器的Get请求
        public ActionResult PostParmsView()
        {
            return View();
        }

        /// <summary>
        /// MVC接收post请求的参数方式：
        /// 1、FormCollection forms ：form["uname"]
        /// 2、Request.Form["uname"]  
        /// 3、定义一个实体对象，此对象中有一个uname的属性
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        //[HttpPost] //作用：负责接收浏览器的Post请求            
        //public ActionResult PostParmsView(FormCollection forms)
        //{
        //    //获取参数uname值
        //    string uname = forms["uname"];

        //    string uname1= Request.Form["uname"];
        //    string uname2 = Request.Params["uname"];

        //    return Content("uname=" + uname);
        //}

        /// <summary>
        /// MVC推荐的接收Post请求参数的方式 3:定义一个实体对象，此对象中有一个uname的属性
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostParmsView(UserInfo userinfo)
        {
            return Content("uname=" + userinfo.uname);
        }

        #endregion
    }
    public class UserInfo
    {
        public string uname { get; set; }
    }
}
