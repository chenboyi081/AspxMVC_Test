# AspxMVC_Test
MVC基础学习，复习（本教程为MVC4.0）

## C01 学习内容：MVC初体验，默认路由规则，action向视图传值的方式
### C01-图：MVC处理机制（简版）
![1](http://images.cnblogs.com/cnblogs_com/chenboyi081/1328731/o_05%20-%20MVC%E5%A4%84%E7%90%86%E6%9C%BA%E5%88%B6%E5%9B%BE%E8%A7%A3-%E7%AE%80%E7%89%88.png)
### C01-图：核心类库图解
![2](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_2018-10-26_221452.png)
### C01-图：知识点全览
![3](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_2018-10-27_070854.png)
---------------------------------------------------------------------------------------------------------

## C02 学习内容：1、ActionResult子类演示，2、url和请求报文传值，3、在action中设置session和获取session 4、可以在View()方法中由程序员指定要返回的视图名称 5、强类型视图和弱类型视图  6、Razor语法演示 7、ViewStart.cshtml 08、layout.cshtml整体布局页的说明
### C02-图：MVC处理机制MVC中get请求一个视图和post一个方法的图解
![1](http://images.cnblogs.com/cnblogs_com/chenboyi081/1328731/o_02%20-%20MVC%E4%B8%ADget%E8%AF%B7%E6%B1%82%E4%B8%80%E4%B8%AA%E8%A7%86%E5%9B%BE%E5%92%8Cpost%E4%B8%80%E4%B8%AA%E6%96%B9%E6%B3%95%E7%9A%84%E5%9B%BE%E8%A7%A3.png)
### C02-图：C02知识全览
![2](http://images.cnblogs.com/cnblogs_com/chenboyi081/1328731/o_2018-11-03_140822.png)
---------------------------------------------------------------------------------------------------------

## C03 学习内容：第一个MVC的增删查改（EF）,分布视图 ,Model(模型 注解)
### C03-分布视图:作用相当于asp.net中的用户自定义控件 .ascx,可以封装同一份逻辑在不同的页面调用
####	return view() 会执行views文件夹下的_viewstart.cshtml页面
####	return PartialView() 不会执行views文件夹下的_viewstart.cshtml页面
####	在视图中调用分部视图的使用：
		<hr />
        1.0在正常视图上调用分部视图方式1<br />
        @Html.Partial("Index", new Pig() { ID = 100, name = "小猪" })
        <br />
        <hr />
        2.0在正常视图上调用分部视图方式2<br />
        @{Html.RenderPartial("Index", new Pig() { ID = 100, name = "小猪" });}

        <br />
        <hr />
        3.0在正常视图上调用分部视图方式2<br />
        @{Html.RenderAction("Index");}
        @*@Html.RenderAction("Index", new {controller="Home" });*@
		
          <br />
        <hr />
		 总结： 上面1.0 和2.0 的方式是直接通过 view 调用 view，<br />
        将视图内容输出在调用视图的指定位置，不会进入控制器的action方法
        <br />
		3.0 通过view 调用 action再由action返回一个视图 ，将视图内容输出在调用视图的指定位置
### C03-Model(模型 注解)	
	注意点：
	 所有验证的元素必须放到 <form>表单中，并且是通过 submit按钮来提交
	 确认MVC网站中 的web.config中的 <add key="ClientValidationEnabled" value="true" /> value值为true
	1、DisplayName(“程序员自定义文字”)配合 @Html.EditorForModel()，  @Html.DisplayNameFor()， @Html.LabelFor()
        @Html.ValidationMessageFor()
        @Html.DisplayNameForModel()
	2、Required（）非空验证 ，使用步骤如下：
		非侵入式脚本的使用 （作用：用来检查form表单中所有元素值的合法性）
		步骤：
		1、在实体属性上打上 [Required(ErrorMessage = "猪名称不能为空")]
		2、元素要使用@Html.TextBoxFor<> 等来生成
		3、在视图 上添加  @Html.ValidationMessageFor(c => c.name) ：用来显示错误提示信息
		4、引入
			<script src="~/Scripts/jquery-1.7.1.js"></script>
			jquery form表单元素数据合法性检查的插件
			<script src="~/Scripts/jquery.validate.js"></script>
			jquery form表单元素数据合法性检查的插件的非侵入式脚本
			<script src="~/Scripts/jquery.validate.unobtrusive.js"></script>
	3、利用@Html.TextBoxFor()方法生成的元素要放到form表单中
	4、[Range(1, 100, ErrorMessage = "id只能取1-100范围中的值")] ：进行范围限制
	5、[RegularExpression("^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$",ErrorMessage="名称只能输入中文")]利用正则表达式来检查元素的值是否满足要求
	6、System.ComponentModel.DataAnnotations.Compare （）标示当前属性和程序员指定的另外一个属性的值要保持一致
	7、[Remote("checkId", "Home", ErrorMessage = "当前id已经被使用，请换一个", HttpMethod="post")] 
	  Remote发出一个post的ajax请求 /Home/checkid 如果id存在则返回 “false” 不存在则返回 "true"
	8、 [DisplayName("xxx")]：标示一个属性的显示值 ，能够被 @Html.EditorForModel()，  @Html.DisplayNameFor()， @Html.LabelFor()解析出来

## C04-MVC第二套增删改查(使用HtmlHelper，模型注释)	MVC第二套删查(使用Ajax，jquery【jquery.tmpl.js】),HtmlHelper的使用,Url的使用，Ajax
### C04-图:MVC_整体请求流程图完整版
![1](http://images.cnblogs.com/cnblogs_com/chenboyi081/1328731/o_01-MVC_%E6%95%B4%E4%BD%93%E8%AF%B7%E6%B1%82%E6%B5%81%E7%A8%8B%E5%9B%BE%E5%AE%8C%E6%95%B4%E7%89%88.png)
### C04-图:MVC中ajax方法的封装以及ajax的写法形式种类
![2](http://images.cnblogs.com/cnblogs_com/chenboyi081/1328731/o_03%20-%20MVC%E4%B8%ADajax%E6%96%B9%E6%B3%95%E7%9A%84%E5%B0%81%E8%A3%85%E4%BB%A5%E5%8F%8Aajax%E7%9A%84%E5%86%99%E6%B3%95%E5%BD%A2%E5%BC%8F%E7%A7%8D%E7%B1%BB.png)
	
### 一、Html中的扩展方法演示
		//1.0 输出form表单的方式1 (html中的弱类型方法)
		@{Html.BeginForm("Edit", "C03HtmlHelper", FormMethod.Post);}
        @Html.TextBox("Name", Model.Name) @* <input type="text" name="Name" id="Name" value="小黄" />*@
        @Html.Password("Name1", Model.Name)<br />
        @Html.CheckBox("Gender", Model.Gender)<br />
        @Html.RadioButton("Gender", true, Model.Gender)
        @Html.RadioButton("Gender", false, !Model.Gender)<br />
        @Html.DropDownList("Type", ViewBag.tlist as SelectList)<br />
        @Html.ActionLink("跳转", "Index", "C03HtmlHelper")   负责生成a标签
		@{Html.EndForm();}
		
		//2.0 输出form表单的方式2 (强类型方法的演示,后面的编辑和新增都使用强类型方法来进行操作)
        @using (Html.BeginForm("Edit", "C03HtmlHelper", FormMethod.Post))
        {
            @Html.TextBoxFor(c => c.Name) <br />
            @Html.PasswordFor(c => c.Name)<br />
            @Html.CheckBoxFor(c => c.Gender) <br />
            @Html.RadioButtonFor(c => c.Gender, true)
            @Html.RadioButtonFor(c => c.Gender, false)
            @Html.DropDownListFor(c=>c.TypeID,ViewBag.tlist as SelectList)
            @Html.ValidationMessageFor(c=>c.TypeID)
        }
		
### 二、实现第2套增删查改
	MVC razor 视图页面生成模板的路径：
	C:\Program Files\Microsoft Visual Studio 11.0\Common7\IDE\ItemTemplates\CSharp\Web\MVC 4\CodeTemplates\AddView\CSHTML
	涉及知识点：
	1、非侵入式脚本验证
	2、模型注解
	3、@Html中相关扩张方法
	4、EF
	
### 三、Url中的方法演示
### 四、Ajax的方法演示
		web.config中的<add key="UnobtrusiveJavaScriptEnabled" value="true" />
		配置，如果设置成true:则开启ajax和前端表单的元素合法性验证这两个非嵌入（非侵入）式脚本
		如果设置成false:则关闭ajax和前端表单的元素合法性验证这两个非嵌入（非侵入）式脚本
### 五、实现第3套增，删，查，改	
		1、@Html中的相关扩展方法
		2、@Ajax的相关扩展方法
		3、非嵌入式验证脚本的使用
		4、非嵌入式ajax脚本的使用
		
## C05 一、路由规则 二、区域 三、MVC过滤器
### C05-图:C05json(),view()的处理区别图解
![1](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_01%20-%20json()view()%e7%9a%84%e5%a4%84%e7%90%86%e5%8c%ba%e5%88%ab%e5%9b%be%e8%a7%a3.png)
### C05-图:C05MVC的过滤器
![2](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_MVC%e7%9a%84%e8%bf%87%e6%bb%a4%e5%99%a8.png)
### C05-图:C05第7个管道事件中的过滤器方法具体的实现步骤
![3](http://images.cnblogs.com/cnblogs_com/chenboyi081/1328731/o_%E7%AC%AC7%E4%B8%AA%E7%AE%A1%E9%81%93%E4%BA%8B%E4%BB%B6%E4%B8%AD%E7%9A%84%E8%BF%87%E6%BB%A4%E5%99%A8%E6%96%B9%E6%B3%95%E5%85%B7%E4%BD%93%E7%9A%84%E5%AE%9E%E7%8E%B0%E6%AD%A5%E9%AA%A4.png)
### 一、路由规则
		1.0、路由规则url的各种定义
 
		1.1、路由调试dll的使用
		1、现将RouteDebuger.dll 引用到MVC网站项目中
		2、将MVC网站的web.config中的<appSetting>节点中添加一个
		 <!--将路由调试插件打开,true:打开调试器，false：关闭调试器-->
			 <add key="RouteDebugger:Enabled" value="true" />  true:调试路由  false：关闭调试
			 
		2.1、参数的约束 		
		2.2、命名空间约束
		在App_Start 文件夹下的RouteConfig.cs类中
	
		routes.MapRoute(
          name: "Default5",
          url: "itcast/{controller}/{action}/{id}/{name}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, name = UrlParameter.Optional }
          , constraints: new { id = "\\d+", name = "^a$" } //约束此路由规则的id参数必须是一个数字 ,name必须是一个a， 如果id和name只要有一个不匹配，则路由规则不会匹配成功
          , namespaces: new string[] { "Ctrl.Mamager2" }//告诉MVC DefaultControllerFactory 去指定的命名空间中查找控制器类，并且获取其Type类型后创建其对象实例存入上下文的ramaphander中
            );
### 二、区域
	区域重要类：必须继承AreaRegistration
	ReportsAreaRegistration类的命名空间必须和所有的控制器类的命名空间保持一致
     作用：1、负责注册此区域的区域路由规则
           2、标示视图引擎查找视图的对应文件夹
	1、MVC中所有的区域都是存在 Areas文件夹下的
	2、一个MVC网站的区域路由规则是先与网站路由规则注册中，是因为在Global.asax Application_Start()中代码的执行顺序决定
	不推荐修改其中的代码的执行顺序，不然有可能出现匹配路由规则紊乱
	3、区域views和网站跟目录下的views文件夹下的web.config的作用是用来表示当前视图继承的父类是webviewpage<tmodel> 如果删除
	web.config 以后将无法找到.cshtml编译后的父类而报错

	4、每个区域Views文件夹的作用：
		1、存放当前区域的所有视图页面
		2、可以存放_viewstart.cshtml页面

	5、每个区域Views下的Share文件夹的作用：
		1、可以存放当前区域的布局页_layout.cshtlm
		
	6、将区域中的控制器单独存放到某个类库中进行管理
		注意点：1、除了将路由规则类提取到此类库中外还要将AreaRegistration 的子类提取过去
		2、要保证控制器类的命名空间与AreaRegistration 的子类 保持一致
		
###	三、MVC过滤器	
	  1、ActionFilterAttribute
		定义：方法过滤器
		过滤器的创建步骤：
		1、定义一个类继承ActionFilterAttribute 重写里面的四个方法
		OnActionExecuting（）
		OnActionExecuted（）
		OnResultExecuting（）
		OnResultExecuted（）

		2、如何将自定义过滤器注册成全局过滤器
		在app_start 文件夹中的类 FilterConfig的你RegisterGlobalFilters（）方法中编写如下代码：
		 /*注册自定义的actionFilterCust 为全局过滤器
		     * 作用:当前mvc站点中有所action在执行之前，之后，结果返回之前，之后都会
		     * 触发actionFilterCust中的相应方法
		    */
		    filters.Add(new actionFilterCust());

		 3、如何将过滤器应用到某个actio上?
		  3.1、在方法上贴上   [actionFilterCust]
		 [actionFilterCust]
		public ActionResult Add(int id)
		{
		    //System.IO.File.WriteAllText(Server.MapPath("/log.txt"), id.ToString());
		    Response.Write("你好，北京");
		    return View();
		}
		
		3.2 在控制器类上贴上   [actionFilterCust]
		  [actionFilterCust]
			 public class HomeController : Controller


	4、actionexecuting()方法中的相关参数演示
	 /// <summary>
        /// 在action方法执行之前被触发
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // HttpContext.Current.Response.Write("方法执行之前输出的内容-OnActionExecuting()");
            filterContext.HttpContext.Response.Write("方法执行之前输出的内容-OnActionExecuting()<br / >");

            //1.0 获取当前OnActionExecuting被触发的时候是调用了哪个action，将其名字取出
            string actionname = filterContext.ActionDescriptor.ActionName;
            filterContext.HttpContext.Response.Write("action名字=" + actionname + "<br />");

            //2.0 获取当前action所在的控制器名称
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            filterContext.HttpContext.Response.Write("控制器名字=" + controllerName + "<br />");

            //3.0 获取当前action方法上贴有哪些特性标签
            object[] attrArr = filterContext.ActionDescriptor.GetCustomAttributes(false);
            //判断当前action上是否贴有[skipLoginAttribute]的特性标签
            object[] skploginArr = filterContext.ActionDescriptor.GetCustomAttributes(typeof(skipLoginAttribute), false);

            //4.0 判断当前action所在的控制器类是否贴有skipLoginAttribute特性标签
            object[] ctlArr = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(skipLoginAttribute), false);

            //手动在此处修改当前action的返回视图,将来可以用作统一登录验证，如果没有登录则跳转到登录页面
            ViewResult addview = new ViewResult();
            addview.ViewName = "add";
            //addview.ViewName = "~/Views/Home/add.cshtml";
            filterContext.Result = addview;
            
            base.OnActionExecuting(filterContext);
        }

			
			
			
			