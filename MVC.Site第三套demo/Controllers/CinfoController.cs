using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Site第三套demo.Controllers
{
    using Model;
    public class CinfoController : Controller
    {
        //
        // GET: /Cinfo/
        #region 列表查询
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //1.0 获取联系人表的所有数据
            phonebookEntities db = new phonebookEntities();
            var list = db.ContactInfoes.Include("GroupInfo").Where(c => c.IsDelete == 0 && c.GroupId >0)
                .Select(c => new{
                      c.ContactName,
                    c.CommonMobile,
                    c.ID,
                    c.GroupInfo.GroupName
                }).ToList();

            //2.0 将联系人的数据集合以 {status:0,msg:"",datas:[{},{}]}
            return Json(new { status=0,msg="ok",datas=list});
        }
        #endregion

        #region 2.0 删除
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //1.0 物理删除
            phonebookEntities db = new phonebookEntities();
            ContactInfo model = new ContactInfo() { ID = id };
            db.ContactInfoes.Attach(model);
            db.ContactInfoes.Remove(model);
            db.SaveChanges();

            //2.0 返回json格式字符串给ajax异步对象
            return Json(new { status = 0, msg = "删除成功" });
        }

        #endregion
    }
}
