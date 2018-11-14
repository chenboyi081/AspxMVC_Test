using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model.ModelViews
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// 登录类
    /// </summary>
    public class LoginInfo
    {
        [DisplayName("登录名"), Required(ErrorMessage = "登录名称非空")]
        public string LoginName { get; set; }
        [DisplayName("密   码"), Required(ErrorMessage = "密码非空")]
        public string LoginPwd { get; set; }
        [DisplayName("验证码"), Required(ErrorMessage = "验证码非空")]
        public string Vcode { get; set; }
    }
}
