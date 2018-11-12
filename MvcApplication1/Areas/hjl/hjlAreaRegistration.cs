using System.Web.Mvc;

namespace MvcApplication1.Areas.hjl
{
    public class hjlAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "hjl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "hjl_default",
                "hjl/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
