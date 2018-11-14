using MVC.Model.ModelViews;
using MVC.Site第二套demo.Attrs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Site第二套demo.Controllers
{
    [SkipLogin]
    public class LoginController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginInfo model)
        {
            //1.0 验证实体属性值的合法性
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "实体验证失败");

                return View();
            }

            //2.0 检查验证码是否合法
            string vcodeFromSession = string.Empty;
            if (Session["vcode"] != null)
            {
                vcodeFromSession = Session["vcode"].ToString();
            }

            if (vcodeFromSession.Equals(model.Vcode, StringComparison.OrdinalIgnoreCase) == false)
            {
                ModelState.AddModelError("", "验证码错误，请重新输入");
                return View();
            }

            //3.0 验证用户名和密码的合法性
            if (model.LoginName != "admin" || model.LoginPwd != "123")
            {
                ModelState.AddModelError("", "用户名或密码错误");
                return View();
            }

            //4.0 将用户存入session
            Session["uinfo"] = model;

            return RedirectToAction("Index", "cinfo");
        }
    }
}
