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

			
## C06  一、利用action过滤器实现MVC站点的统一登录验证（在第二套增删改查中实现） 二、MVC中 webapi的使用 和 在其他网站中如何来调用（MVC）	三、重写defulatControllerFactoty ,和 RazorViewEnginee 来实现MVC的插件式开发		
### C06-图:在一个网站中请求webapi的代码写法
![1](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_%e5%9c%a8%e4%b8%80%e4%b8%aa%e7%bd%91%e7%ab%99%e4%b8%ad%e8%af%b7%e6%b1%82webapi%e7%9a%84%e4%bb%a3%e7%a0%81%e5%86%99%e6%b3%95.png)
### C06-图:C06MVC处理机制的默认控制器工厂和视图引擎的详细解析
![2](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_MVC%e5%a4%84%e7%90%86%e6%9c%ba%e5%88%b6%e7%9a%84%e9%bb%98%e8%ae%a4%e6%8e%a7%e5%88%b6%e5%99%a8%e5%b7%a5%e5%8e%82%e5%92%8c%e8%a7%86%e5%9b%be%e5%bc%95%e6%93%8e%e7%9a%84%e8%af%a6%e7%bb%86%e8%a7%a3%e6%9e%90.png)

### 一、登录验证：
	1、统一登录验证是写在OnActionExecuting()方法中
	2、当session为null的时候返回登录视图的两种写法
		2.1、
		filterContext.HttpContext.Response.Redirect("/Login/Login"); 
		//缺点：浏览器会提心出现“此网页包含重定向循环”提醒后看不到正常的页面

		2.2、为了解决上面弄2.1的缺点，改成指定返回的视图
		   ViewResult view = new ViewResult();
                view.ViewName = "/Views/Login/Login.cshtml";
                filterContext.Result = view;
		引发另外一个缺点：不会将url路径修改成/Login/Login还是保持原有的/Home/index
		将来在登录按钮被点击的时候，还是提交到了/Home/Index 如何解决：
		在 login.cshtml 中的使用 @Html.BeginForm()的时候指定提交的控制器和action方法即可
	3、将统一登录过滤器注册成全局的过滤器，引发了缺点：
	如果使用的是filterContext.HttpContext.Response.Redirect("/Login/Login");  ，出现出现“此网页包含重定向循环”提醒后看不到正常的页面
	如何解决：
	在loingController上打上自定义的特性标签[skipchecklogin] 在OnActionExecuting() 统一进行判断	
	
### 二、webapi简单使用以及调用（网络爬虫初步实现以及静态页面）：
	1、webapi的路由规则注册在App_Start\WebApiConfig.cs文件中
	2、webapi控制器继承父类 apiController
	3、调用webapi的方式：
		get请求http://localhost/api/home/1 则默认请求 Home控制器下的Get方法将1作为get（）方法的参数
		Post请求http://localhost/api/home/1 则默认请求 Home控制器下的Post方法将1作为Post（）方法的参数
	4、将webapi默认的返回格式设置成json格式写法
		 public static class WebApiConfig
		{
        public static void Register(HttpConfiguration config)
        {
            //将webapi中的XmlFormatter 移除，默认就是以JsonFormatter作为其传输格式
            config.Formatters.Remove(config.Formatters.XmlFormatter);
		}
		
	4、在另外一个网站请求使用httpwebrequest 请求webapi示例：
		 //模拟浏览器请求http://localhost:55749/api/values/GetPig 传入指定的id参数值
         string requestUrl = "http://localhost:15405/infos.ashx?id=" + txtid.Text;
		//1.0 实例化web请求对象的实例
		WebRequest request = WebRequest.Create(requestUrl);
		//2.0 设置其请求方式为get请求
		request.Method = "get";
		//3.0 获取服务器响应回来的响应报文对象
		WebResponse response = request.GetResponse();
		System.IO.Stream str = response.GetResponseStream();

		//将流转换成字符串
		string responsebody = "";
		using (System.IO.StreamReader srd = new System.IO.StreamReader(str))
		{
			//将响应报文体中的数据转换成字符串
			responsebody=srd.ReadToEnd();
		}

		Response.Write(responsebody);
### 三、重写defulatControllerFactoty ,和 RazorViewEnginee 来实现MVC的插件式开发
		2.1、将控制器提取到插件项目中实现步骤
		2.1.1、定义一个类继承DefaultControllerFactory ，重写里面的方法GetControllerType
		 protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
     
	 例子：
	  public class PluginControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            Type controllerType = null;
            //1.0 当浏览器发出一个url请求的时候，在管道事件第7个上会触发控制器创建动作，一定触发工厂中GetControllerType方法
            //所以，在此处就先从网站主站的Plugins文件夹 通过反射创建一个当前请求控制器的 Type ,如果没有找到，则一定会返回null
            //那么此时就调用base.GetControllerType(requestContext, controllerName); 从当前网站的bin目录下查找

            //1.0 获取当前网站的运行目录
            string phyPath = AppDomain.CurrentDomain.BaseDirectory;
            //2.0 获取当前网站的插件目录
            string plugsPahyPath = phyPath + "Plugins";

            //3.0 将传入的controllerName 加上固定后缀"Controller"
            string pullName = controllerName + "Controller";

            //4.0 通过程序集中的GetType()方法获取当前控制器的Type对象
            //4.0.1 获取Plugins 下面的所有后缀名为 .dll的程序集路径
            string[] dllfilePhyPaths = System.IO.Directory.GetFiles(plugsPahyPath, "*.dll", System.IO.SearchOption.AllDirectories);

            //5.0 遍历dll的物理路径将dll加载的Assembly 中
            if (dllfilePhyPaths != null && dllfilePhyPaths.Length > 0)
            {
                foreach (var dllfilephyPath in dllfilePhyPaths)
                {
                    //5.0.1 根据dll的物理路径将dll加载到dllass中
                    Assembly dllass = Assembly.LoadFile(dllfilephyPath);
                    controllerType = dllass.GetType("MVC.Plugs.Controllers." + pullName);
                    if (controllerType != null)
                    {
                        break;
                    }
                }
            }

            if (controllerType != null)
            {
                return controllerType;
            }

            return base.GetControllerType(requestContext, controllerName);
        }
    }
	
	2.1.2、在MVC主网站跟目录下定义一个 Plugins文件夹，将插件中生成的dll拷贝到其中
	2.1.3、在mvc主网站的Global.asax中的  Application_Start() 方法中加入如下代码：
		将MVC控制器类的创建行为动作交给自己定义好的PluginControllerFactory 工厂
        ControllerBuilder.Current.SetControllerFactory(new PluginControllerFactory());
		
	2.2、将视图提取到插件项目中实现步骤
	 1、
	 public class PluginsRazorViewEngine : RazorViewEngine
	 {
        /// <summary>
        /// 自己定义 视图引擎查找视图的路径
        /// </summary>
        private string[] ViewLocationFormats ={
                            "~/Plugins/Order/Views/{1}/{0}.cshtml",
                           "~/Plugins/Order/Views/Shared/{1}/{0}.cshtml",
                           "~/Views/{1}/{0}.cshtml",
                           "~/Views/Shared/{1}/{0}.cshtml",
                                              };

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            //1.0 将父类RazorViewEngine中的ViewLocationFormats设置成本类定义的路径
            base.ViewLocationFormats = this.ViewLocationFormats;

            //2.0 重写视图引擎将 视图编译成前台页面类的方法
            RazorBuildProvider.CodeGenerationStarted += RazorBuildProvider_CodeGenerationStarted;


            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        void RazorBuildProvider_CodeGenerationStarted(object sender, EventArgs e)
        {
            RazorBuildProvider provider = sender as RazorBuildProvider;
            //将哪个程序集编译到当前视图引用中
            //1.0 获取当前网站的运行目录
            string phyPath = AppDomain.CurrentDomain.BaseDirectory;
            //2.0 获取当前网站的插件目录
            string plugsPahyPath = phyPath + "Plugins";

            //4.0 通过程序集中的GetType()方法获取当前控制器的Type对象
            //4.0.1 获取Plugins 下面的所有后缀名为 .dll的程序集路径
            string[] dllfilePhyPaths = System.IO.Directory.GetFiles(plugsPahyPath, "MVC.Plugs.dll", System.IO.SearchOption.AllDirectories);

            string mvcplugsdllPath = dllfilePhyPaths[0];

            Assembly ass = Assembly.LoadFile(mvcplugsdllPath);

            //5.0 将ass 添加为视图前台页面类的引用程序集
            provider.AssemblyBuilder.AddAssemblyReference(ass);

        }
	 
	2、在mvc主网站的Global.asax中的  Application_Start() 方法中加入如下代码：
	 //移除当前MVC主站点中的所有视图引擎
            ViewEngines.Engines.Clear();
            //将自己定义好的引擎添加到MVC中
            ViewEngines.Engines.Add(new PluginsRazorViewEngine());
			
## C07 	网站性能优化以及分布式网站（参考PPT:[服务器架构及memcached部署中一致性Hash的应用]）
### C07-图：服务器的划分
![1](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_%e6%9c%8d%e5%8a%a1%e5%99%a8%e7%9a%84%e5%88%92%e5%88%86%20.png)
### C07-图：web服务器的负载均衡优化
![2](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_web%e6%9c%8d%e5%8a%a1%e5%99%a8%e7%9a%84%e8%b4%9f%e8%bd%bd%e5%9d%87%e8%a1%a1%e4%bc%98%e5%8c%96.png) 
### C07-图：网站前端优化
![3](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_%e7%bd%91%e7%ab%99%e5%89%8d%e7%ab%af%e4%bc%98%e5%8c%96.png)
### C07-图：聚集索引和非聚集索引 & 分表算法（求余法）
![4](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_%e8%81%9a%e9%9b%86%e7%b4%a2%e5%bc%95%e5%92%8c%e9%9d%9e%e8%81%9a%e9%9b%86%e7%b4%a2%e5%bc%95%20_%20%e5%88%86%e8%a1%a8%e7%ae%97%e6%b3%95%ef%bc%88%e6%b1%82%e4%bd%99%e6%b3%95%ef%bc%89.png)
### C07-图：分表法之（路由表（索引表）法）
![5](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_%e5%88%86%e8%a1%a8%e6%b3%95%e4%b9%8b%ef%bc%88%e8%b7%af%e7%94%b1%e8%a1%a8%ef%bc%88%e7%b4%a2%e5%bc%95%e8%a1%a8%ef%bc%89%e6%b3%95%ef%bc%89.png)
### C07-图：db的主从分离（读写分离）
![6](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_db%e7%9a%84%e4%b8%bb%e4%bb%8e%e5%88%86%e7%a6%bb(%e8%af%bb%e5%86%99%e5%88%86%e7%a6%bb).png)
### C07-图：关系型db和nosqldb的图解
![7](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_%e5%85%b3%e7%b3%bb%e5%9e%8bdb%e5%92%8cnosqldb%e7%9a%84%e5%9b%be%e8%a7%a3.png)
### C07-图：C07知识点的总体总结
![8](https://www.cnblogs.com/images/cnblogs_com/chenboyi081/1328731/o_%e7%9f%a5%e8%af%86%e7%82%b9%e7%9a%84%e6%80%bb%e4%bd%93%e6%80%bb%e7%bb%93.png)		
			
	网站分类：1、企业管理系统  ，CRM，OA，ERP，进销存,企业内部使用的系统
		2、互联网站点，在线商城，在线交友，论坛，CMS（内容管理系统），有更高的访问量
		PV：page view 页面浏览量，每天的页面浏览量
		
	分布式系统开发：
		1、基础功能（业务的CRUD）还是会使用asp.net的基础知识来进行开发
		2、利用外面开源或者商业的或者自己开发的软件来进行多台服务器共同支撑同一个站点的解决方案
	
	Http和https
	
	https：通讯方式，公钥和私钥，作用：会将请求数据加密以后才在网络上传输

### 自购服务器解决的问题：
	1、带宽独享
	2、性能更加优越
	ps：自购网站需要机房托管，以及域名解析(www.dnspod)等



### 1、网站的集群：使用多台服务器来支撑当前业务的处理，比如登录这一功能可以用10台服务器来支撑
### 2、负载均衡有两种方式：
	1、通过DNS的解析来做，但是不能做到真正的均衡
	2、引入一台代理服务器(linux+nginx)，实现真正的负载均衡

-----------------------优化站点------------------
### 3、优化HTTP请求，减少请求次数
	3.1、通过合并多张小图到一张大图中，利用css定位来查找不同的小图,能够减少http的请求
	3.2、尽量将同一个逻辑的css代码和js代码放到同一个文件中，这样也能够减少http的请求
	3.3、可以将图片和js，css等静态资源文件通过CDN缓存来减少HTTP的请求
		CDN:安全宝可以免费使用
		1、可以将网站的 静态资源缓存，根据请求的ip地址获取最近 的一台CDN节点将资源返回给用户
		2、可以帮助抵御大量请求攻击 DDos攻击，网宿科技 可以抵御30g的DDos攻击		
	
	热切换
	
### 4、优化每一次http请求资源的大小
	4.1、IIS会默认开启GZip的静态资源压缩
	4.2、尽量在不失真的情况下优化图片资源（减少图片的大小,firework可以实现）
	4.3、尽量在网站发布以后使用压缩以后的js和css文件

	
### 5、前台页面缓存
	指令集:<%@outputcache Durion = "10" %>  前台页面的本质：服务器设置last-modified和exprise 的时间 ，浏览器请求的时候会将last-modified
	的时间通过If-Modifiec-Since 发送给服务器

### 6、数据的缓存
	6.1、数据库缓存依赖
	6.2、文件缓存依赖
	6.3、绝对过期时间使缓存失效
	6.4、相对过期时间使缓存失效

 -----------------------优化站点------------------	
	
### 7、CDN是什么
	4.1、CDN俗称网站加速
	4.2、公司一般是购买其他cdn服务商提供的服务
	4.3、CDN一般是用来缓存网站的静态资源文件的（css,js,图片,html,htm）,浏览器获取某个静态资源是按照就近原则
	4.4、所谓就近原则：DNS服务器通过浏览器发送过来socket链接，就可以获取到当前浏览器的IP地址，根据IP就可以获取当前浏览器所在的城市
	CDN就会根据IP地址所对应的城市获取其最近的CDN服务器节点
	4.5、当web站点中的静态资源有更新的时候，CDN应该也要更新它的缓存，这个操作 叫做 “回源”
	
### 8、增加一台web服务器后引发的问题和解决方案
	8.1、利用nginx做负载均衡
		注意：nginx在windows下面仅仅只能用于演示，不能提供真正的服务，因为nginx在window上有http请求限制当达到它设置的阀值时就不会再处理其他的http请求了
		所以nginx一定要放到linux下面运行,才能够发挥它真正的性能（linux下的epoll模式，windows下是用的是多线程模式，以消息驱动的）
		
	热切换
	
### 9、nginx有两个功能：
	9.1、用作反向代理实现负载均衡
	9.2、可以通过扩展安装缓存模块来是实现网站静态资源的缓存（squid 也可以实现网站静态资源的缓存）
	Nginx +  squid -->对于静态资源的缓存可以使用更加廉价的CDN来实现，可以利用云服务器来存储你的静态资源
	nginx在linux下的命令：
	nginx start
	nginx stop
	nginx restart      --重启，当运行这个命令对nginx进行重启时，所有用户不能访问
	nginx force_reload --平滑重启 当运行这个命令对nginx进行重启时，所有用户照常访问	
	注意点：1、nginx不能放到中文目录
			2、检查nginx的配置文件中监听端口是否被别的软件占用了
			
	
### 10、机械硬盘 < 固态硬盘 < 硬盘磁带 
	磁盘阵列，Rd1  -- Rd6
	
### 11、分库后的不同数据库中的表访问方式可以通过 同义词 来做别名
	CREATE SYNONYM  --创建同义词的关键字
	[dbo].[TestBTbA]  --同义词名称，在select语句的from后面直接被使用
	FOR [TestB].[dbo].[TbA]  --当前同义词所映射的其他数据中的表

### 12、如果两个数据库分别存放在不同的物理机器上，那么他们之间通过普通的同义词就不能够互相访问了，

	sqlserver2005:链接服务器 ，sqlserver2000没有链接服务器
	slqserver2008以上：
	
	这时必须要在创建同义词的时候指定 链接服务器名称
	如何在一个数据库中建立 另外一个数据服务器的 链接服务器 ？
		可以通过系统存储过程 sp_addlinkedserver 来添加其他数据库服务器的链接服务器
		例如：exec sp_addlinkedserver   '链接服务器的别名', '', 'SQLOLEDB', '192.168.10.2,1433'
		这个时候创建同义词的方式为：
		CREATE SYNONYM  --创建同义词的关键字
		[dbo].[TestBTbA]  --同义词名称，在select语句的from后面直接被使用
		FOR [链接服务器的别名].[TestB].[dbo].[TbA]  --当前同义词所映射的其他数据中的表
	
### 13、数据库的主从分离主要目的是用来减少磁盘读和写的竞争，主从之间的数据同步是通过主数据开启一个本地发布，从数据库开启一个本地订阅

###14、磁盘IO的竞争
	调度器（企业总线） 
	c# 开源项目;Shuttle（飞梭） ,基于windows消息队列(MSMQ)


### *总结：
1、网站前端优化
	1.1、减少http请求 （合并css，js文件，cdn做静态资源缓存）
	1.2、减少http请求的传输量  （压缩js，css，图片）
	
2、将iis最大处理进程由1变<=5的一个数 （web园）
3、将web服务器扩充到2台以上
		问题：
		通过进程外session来解决session共享的问题
		通过使用redis或者memcached缓存软件来统一管理缓存数据
		通过文件服务器统一管理用户上传到服务器的附件
		使用nginx做负载均衡
		
4、将业务逻辑分离成不同的业务子站点，发布到不同的应用服务器上运行
5、分表（求余法，路由表），分库，主从（读写）分离
	分库以后，各业务数据库可以通过【链接服务器】 和【同义词】来进行通讯
	
6、使用nosql来存储事务不强的数据
7、一致性hash算法

网站优化：
回答要点
1、网站前端优化
2、数据缓存（缓存失效策略，数据库依赖缓存（只属于sqlserver））（分布式缓存，redis，memcached 之间的优缺点）
3、分库，分表策略
4、主从分离
			