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

        #region 3.0 新增

        [HttpGet]
        public ActionResult Add()
        {
            phonebookEntities db = new phonebookEntities();
            var glist = db.GroupInfoes.ToList();
            SelectList slist = new SelectList(glist, "GroupId", "GroupName");
            ViewBag.glist = slist;
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContactInfoView model)
        {
            System.Threading.Thread.Sleep(2000);        //实际项目中不能这么做
            //1.0 验证实体属性的值的合法性
            if (ModelState.IsValid == false)
            {
                //PhoneBookEntities db = new PhoneBookEntities();
                //var glist = db.GroupInfo.ToList();
                //SelectList slist = new SelectList(glist, "GroupId", "GroupName");
                //ViewBag.glist = slist;
                //return View();
                return Json(new { status = 1, msg = "实体属性值的合法性验证失败" });
            }

            //2.0 
            try
            {
                ContactInfo entity = new ContactInfo()
                {
                    Account = "1",
                    ContactId = "1",
                    CommonMobile = model.CommonMobile,
                    ContactName = model.ContactName,
                    GroupId = model.GroupId,
                    IsDelete = 0
                };

                phonebookEntities db = new phonebookEntities();
                db.ContactInfoes.Add(entity); //1、将entity追加到EF容器中， 2、修改状态类的状态为added
                db.SaveChanges();

                return Json(new { status = 0, msg = "新增成功" });
            }
            catch (Exception ex)
            {
                return Json(new { status = 1, msg = ex.Message });
            }
        }
        #endregion
    }
}
