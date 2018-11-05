using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC体验.Models
{
    using System.ComponentModel;        //验证
    using System.ComponentModel.DataAnnotations;  //验证
    using System.Web.Mvc;  //验证
    public class Person
    {
        [DisplayName("人名称")]
        [Required(ErrorMessage="人名称非空")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "猪名称的长度介于1到10之间")]
        [Remote("CheckName", "C032ZJ", HttpMethod = "post", ErrorMessage = "用户名称已存在，请换一个")]
        public string Name { get; set; }
         [DisplayName("人年龄"), Required(ErrorMessage = "人年龄非空"), Range(1, 500, ErrorMessage = "人年龄只能介于1到500之间")]
        public int Age { get; set; }
        [DisplayName("密码")]
        public string Pwd { get; set; }
         [System.ComponentModel.DataAnnotations.Compare("Pwd", ErrorMessage = "确认密码必须与原始密码保持一致")]
         [DisplayName("确认密码")]
        public string ConfrimPwd { get; set; }
         [RegularExpression("^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$", ErrorMessage = "Email格式不合法")]
         [DisplayName("邮箱")]
        public string Email { get; set; }
    }
}