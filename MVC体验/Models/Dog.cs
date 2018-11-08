using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC体验.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Dog
    {
        [Required(ErrorMessage = "名称非空")]
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int TypeID { get; set; }
    }
}