using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC体验.Controllers.C03
{
    using MVC.Model;
    using System.Web.WebPages; //引用该命名空间后，就可以使用IsInt()和AsInt()方法了
    using System.Data.Entity.Infrastructure;
    /// <summary>
    /// MVC增删查改操作(第一套)
    /// </summary>
    public class CInfoController : Controller
    {
        #region 查询
        public ActionResult Index()
        {
            phonebookEntities db = new phonebookEntities();
            // select c.*,g.* from ContactInfo c, Left Join GroupInfo g on (c.GroupID=g.GroupID)  where c.IsDelete=0
            var list = db.ContactInfoes.Include("GroupInfo").Where(c => c.IsDelete == 0 && c.GroupId > 0).ToList();
            return View(list);
        }
        #endregion

        #region 新增
        [HttpGet]
        public ActionResult Add()
        {
            phonebookEntities db = new phonebookEntities();

            //2.0 获取grouinfo的所有数据以ViewBag.glist
            ViewBag.glist = db.GroupInfoes.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Add(ContactInfo model)
        {
            //1.0 补全model中没有赋值，但是数据库中不允许有null值的字段
            model.ContactId = "1";
            model.Account = "123";

            //2.0 实例化EF上下文对象
            phonebookEntities db = new phonebookEntities();
            //2.0.1 将model追加到EF容器中，并且将状态修改成added
            db.ContactInfoes.Add(model);

            //2.0.2 统一保存
            db.SaveChanges();

            return Content("<script>alert('新增成功');window.location='/CInfo/Index'</script>");
        }
        #endregion

        #region 修改
        [HttpGet]
        public ActionResult Edit(string id)
        {
            //合法性验证
            if (id.IsInt() == false || id == null)
            {
                return Content("<script>alert('数据不存在或编辑错误');window.location='/CInfo/Index'</script>");
            }

            //1.0 实例化EF上下文
            phonebookEntities db = new phonebookEntities();

            //2.0 获取grouinfo的所有数据以ViewBag.glist
            ViewBag.glist = db.GroupInfoes.ToList();

            //3.0 
            int iid = id.AsInt();
            var model = db.ContactInfoes.FirstOrDefault(c => c.ID == iid);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string id, ContactInfo model)
        {
            //合法性验证
            if (id.IsInt() == false || id == null)
            {
                return Content("<script>alert('数据不存在或编辑错误');window.location='/CInfo/Index'</script>");
            }

            phonebookEntities db = new phonebookEntities();
            int iid = id.AsInt();
            //TODO:第一种编辑方式
            //var entity = db.ContactInfo.FirstOrDefault(c => c.ID == iid);

            //entity.ContactName = model.ContactName;
            //entity.CommonMobile = model.CommonMobile;
            //entity.GroupId = model.GroupId;

            //db.SaveChanges();

            //TODO: 第二种编辑方式
            model.ID = id.AsInt();
            DbEntityEntry entry = db.Entry(model);
            entry.State = System.Data.EntityState.Unchanged;
            entry.Property("ContactName").IsModified = true;
            entry.Property("CommonMobile").IsModified = true;
            entry.Property("GroupId").IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;     //关闭检查

            db.SaveChanges();

            return Content("<script>alert('编辑成功');window.location='/CInfo/Index'</script>");
        }
        #endregion

        #region 删除
        public ActionResult delete(string id)
        {
            //1.0 id的合法性验证
            if (id.IsInt() == false || id == null)
            {
                return Content("<script>alert('数据不存在或其他错误');window.location='/CInfo/Index'</script>");
            }

            //2.0 将id对应的数据进行物理删除
            ContactInfo model = new ContactInfo() { ID = id.AsInt() };

            phonebookEntities db = new phonebookEntities();

            db.ContactInfoes.Attach(model);
            db.ContactInfoes.Remove(model);

            db.SaveChanges();

            return Content("<script>alert('删除成功');window.location='/CInfo/Index'</script>");
        }
        #endregion
    }
}
