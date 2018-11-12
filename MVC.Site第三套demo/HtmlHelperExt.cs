using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Site第三套demo
{
    /// <summary>
    /// 自定义HtmlHelper扩展类
    /// </summary>
    public static class HtmlHelperExt
    {
        public static MvcHtmlString SubmitCreate(this HtmlHelper html, string value)
        {
            string fmtstr = "<input type=\"submit\" value=\"{0}\" />";

            return new MvcHtmlString(string.Format(fmtstr, value));
        }
    }
}