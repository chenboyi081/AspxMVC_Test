//------------------------------------------------------------------------------
// <auto-generated>

namespace MVC.Model
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ContactInfoView
    {
        [DisplayName("���")]
        public int ID { get; set; }
        public string ContactId { get; set; }
        public int IsDelete { get; set; }
        public string Account { get; set; }
        [DisplayName("����"), Required(ErrorMessage = "���Ʒǿ�")]
        public string ContactName { get; set; }
        [DisplayName("�绰"), Required(ErrorMessage = "�绰�ǿ�")]
        public string CommonMobile { get; set; }
        public string HeadPortrait { get; set; }
        public string AttFile { get; set; }
        [DisplayName("��������")]
        public Nullable<int> GroupId { get; set; }

        public virtual GroupInfoView GroupInfo { get; set; }
    }
}