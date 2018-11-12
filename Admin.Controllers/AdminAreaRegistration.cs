using System.Web.Mvc;
using System.Web;

namespace Admin.Controllers
{
    /// <summary>
    /// 区域重要类：必须继承AreaRegistration
    /// 作用：1、负责注册此区域的区域路由规则
    ///          2、标示视图引擎查找视图的对应文件夹
    /// 
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 用于标示视图引擎查找视图的对应文件夹
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        /// <summary>
        /// 负责向当前MVC网站的RouteCollection 路由集合中注册区域路由规则的方法
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
