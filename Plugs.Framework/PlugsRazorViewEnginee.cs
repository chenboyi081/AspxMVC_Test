using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugs.Framework
{
    using System.Web.Mvc;
    using System.Web.WebPages.Razor;
    using System.Reflection;

    /// <summary>
    /// 重写了默认视图引擎
    /// </summary>
    public class PlugsRazorViewEnginee : RazorViewEngine
    {
        string[] ViewLocationFormatsPlugs = { 
                                            "~/Plugs/Order/Views/{1}/{0}.cshtml",
                                            "~/Plugs/Order/Views/Shared/{0}.cshtml",   
                                             "~/Views/{1}/{0}.cshtml",
                                            "~/Views/Shared/{0}.cshtml"
                                            };

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            //1.0 将public string[] ViewLocationFormats { get; set; } 属性重新赋值 
            base.ViewLocationFormats = ViewLocationFormatsPlugs;

            //2.0 重写视图引擎将 视图编译成前台页面类的方法
            RazorBuildProvider.CodeGenerationStarted += RazorBuildProvider_CodeGenerationStarted;

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        void RazorBuildProvider_CodeGenerationStarted(object sender, EventArgs e)
        {
            RazorBuildProvider bulid = sender as RazorBuildProvider;
            //1.0 将Plugs.MVC.Order.dll 编译到类引用中
            Assembly ass = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + @"\Plugs\OrderInfo\bin\Plugs.MVC.Order.dll");

            //2.0 将 Plugs.MVC.Order.dll程序集添加为文件生成的源代码所引用的程序集。
            bulid.AssemblyBuilder.AddAssemblyReference(ass);
        }
    }
}
