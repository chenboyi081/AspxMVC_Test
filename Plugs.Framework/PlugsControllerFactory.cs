using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugs.Framework
{
    using System.Web.Mvc;
    using System.IO;
    using System.Reflection;

    public class PlugsControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            //1.0根据传入的参数controllerName 去Plugs下面查找所有的.dll 创建控制器的Type
            string controllerNameFull = controllerName + "Controller";

            //2.0 扫描当前Plugs下面的所有dll
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string plugsPath = basePath + @"\Plugs\";
            string[] filePaths = Directory.GetFiles(plugsPath, "*.dll", SearchOption.AllDirectories);
            Type controllerType = null;
            if (filePaths != null && filePaths.Any())
            {
                foreach (var filePath in filePaths)
                {
                    //根据单个dll的完整路径将dll加载到Assembly中
                    Assembly ass = Assembly.LoadFile(filePath);
                    controllerType = ass.GetType("Plugs.MVC.Order.Controllers." + controllerNameFull, false, true);

                    //默认使用第一个找到的控制器
                    if (controllerType != null)
                    {
                        break;
                    }
                }
            }

            if (controllerType != null)
            {
                return controllerType;
            }
            else
            {
                //去当前运行网站的bin目录查找dll，获取控制器类的type
                return base.GetControllerType(requestContext, controllerName);
            }
        }
    }
}
