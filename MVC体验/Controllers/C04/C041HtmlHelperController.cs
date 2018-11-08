using MVC体验.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C04
{
    /// <summary>
    /// 负责演示@Html 中的扩展方法，具体请看 Index.cshtml视图
    /// </summary>
    public class C041HtmlHelperController : Controller
    {
        //
        // GET: /C041HtmlHelper/

        public ActionResult Edit()
        {
            Dog dog = new Dog()
            {
                Name = "小黄"
                ,
                Age = 2,
                Gender = false,
                TypeID = 2
            };

            List<Types> tlist = new List<Types>() { 
            new  Types(){ TName="类型1", Tid=1},
            new  Types(){ TName="类型2", Tid=2}
            };
            /*
             * SelectList:作用配合@Html.DropDownlist() @Html.DropDownlistFor()  两个使用的
             * 第1个参数：List集合
             * 第2个参数：生成到option中的value中的属性名称
             * 第3个参数：生成到option中的text中的属性名称
             * 第4个参数：指定要从绑定后的所有option中选择的对象项，和option中的value值进行比对
             */
            //SelectList list = new SelectList(tlist, "Tid", "TName", 2); 配合@Html.DropDownlist()  方法的默认选择值
            SelectList list = new SelectList(tlist, "Tid", "TName");

            //将list传入视图edit.cshtml
            ViewBag.tlist = list;

            return View(dog);
        }

    }
}
public class Types
{
    public int Tid { get; set; }
    public string TName { get; set; }
}