using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Site第二套demo.Controllers
{
    using MVC.Model;
    public class CInfoController : Controller
    {
        //
        // GET: /CInfo/

        public ActionResult Index()
        {
            //1.0 
            phonebookEntities db = new phonebookEntities();
            var list = db.ContactInfoes
                .Include("GroupInfo")
                .Where(c => c.IsDelete == 0 && c.GroupId > 0)
                .Select(c => new ContactInfoView()
                {
                    ID = c.ID,
                    ContactName = c.ContactName,
                    CommonMobile = c.CommonMobile
                    ,
                    GroupInfo = new GroupInfoView() { GroupName = c.GroupInfo.GroupName }
                }).ToList();

            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            phonebookEntities db = new phonebookEntities();
            //1.0 根据id加载老数据实体
            var model = db.ContactInfoes.Where(c => c.ID == id)
                .Select(c =>
                    new ContactInfoView()
                    {
                        ContactName = c.ContactName
                        ,
                        CommonMobile = c.CommonMobile
                        ,
                        GroupId = c.GroupId
                    }).FirstOrDefault();


            //2.0 将GroupInfo中的所有数据以SelectList的形式通过ViewBag.glist 传入edit.cshtml
            SetGlist();

            return View(model);
        }

        private void SetGlist()
        {
            phonebookEntities db = new phonebookEntities();

            var glist = db.GroupInfoes.ToList();
            SelectList slist = new SelectList(glist, "GroupId", "GroupName");
            ViewBag.glist = slist;
        }

        [HttpPost]
        public ActionResult Edit(int id, ContactInfoView model)
        {
            //0.0 检查model实体的属性的合法性
            if (ModelState.IsValid == false)
            {
                //验证失败，则应该跳转回edit.cshtml视图,同时增加一个错误提醒
                SetGlist();
                //向视图增加一个错误提醒，配合视图中的@Html.ValidateionSummary(true) 来使用
                ModelState.AddModelError("", "实体验证失败，请检查");

                return View();
            }

            try
            {
                //1.0 通过EF的推荐方式 ，先查在修改
                phonebookEntities db = new phonebookEntities();
                //var entity = db.ContactInfo.FirstOrDefault(c => c.ID == id);
                //entity.CommonMobile = model.CommonMobile;
                //entity.ContactName = model.ContactName;
                //entity.GroupId = model.GroupId;
                //db.SaveChanges();

                //2.0 通过自定义实体的方式 ，先追加再修改状态
                //补全id属性的值
                model.ID = id;  //update ContactInfo set CommonMobile=,ContactName=,GroupId where iD=1
                //将model追加到EF容器中
                ContactInfo entity = new ContactInfo()
                {
                    ID = model.ID,
                    GroupId = model.GroupId,
                    ContactName = model.ContactName,
                    CommonMobile = model.CommonMobile
                };
                //将entity追加到EF容器中
                System.Data.Entity.Infrastructure.DbEntityEntry enty = db.Entry(entity);
                //修改其状态
                enty.State = System.Data.EntityState.Unchanged;
                //将要修改的属性的IsModified设置成true
                enty.Property("CommonMobile").IsModified = true;
                enty.Property("ContactName").IsModified = true;
                enty.Property("GroupId").IsModified = true;
                //关闭EF的实体检查
                db.Configuration.ValidateOnSaveEnabled = false;

                //统一将sql语句发送给db执行
                db.SaveChanges();

                //直接跳转到 cinfo/index 页面
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SetGlist();
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

    }
}
