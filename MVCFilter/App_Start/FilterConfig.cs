using System.Web;
using System.Web.Mvc;

namespace MVCFilter
{
    using MVCFilter.Filters;
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //将自定义类ActionFilterCust 注册成了全局过滤器(截获此网站中所有action的执行，AOP：面向切面编程)
            filters.Add(new ActionFilterCust());
            filters.Add(new AuthorFilter());
            filters.Add(new ExceptionFilter());
        }
    }
}