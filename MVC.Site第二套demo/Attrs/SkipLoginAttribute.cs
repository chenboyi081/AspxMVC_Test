using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Site第二套demo.Attrs
{
    /// <summary>
    /// 自定义特性标签，用于跳过统一的登录验证检查（想要某个控制器跳过，则在控制器或者action方法上贴上此标签集合）
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SkipLoginAttribute:Attribute
    {

    }
}