using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ctrl.Mamager2
{
    public class HomeController : Controller
    {
        
        // GET: /Home/
        public ActionResult Index()
        {
            return Content("我爱北京天安门 from Ctrl.Mamager2 ");
        }
    }
}
