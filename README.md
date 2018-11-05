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

	4、确认MVC网站中 的web.config中的 <add key="ClientValidationEnabled" value="true" /> value值为true

	5、注意点：
	 所有验证的元素必须放到 <form>表单中，并且是通过 submit按钮来提交

	6、[Range(1, 100, ErrorMessage = "id只能取1-100范围中的值")] ：进行范围限制
	7、[RegularExpression("^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$",ErrorMessage="名称只能输入中文")]利用正则表达式来检查元素的值是否满足要求
	8、System.ComponentModel.DataAnnotations.Compare （）标示当前属性和程序员指定的另外一个属性的值要保持一致
	9、[Remote("checkId", "Home", ErrorMessage = "当前id已经被使用，请换一个", HttpMethod="post")] 
	  Remote发出一个post的ajax请求 /Home/checkid 如果id存在则返回 “false” 不存在则返回 "true"
	10、 [DisplayName("xxx")]：标示一个属性的显示值 ，能够被 @Html.EditorForModel()，  @Html.DisplayNameFor()， @Html.LabelFor()解析出来
		