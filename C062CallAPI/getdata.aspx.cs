using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace C062CallAPI
{
    public partial class getdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 请求MVCWebapi中的数据
        /// http://localhost:31058/api/Values/GetPig
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btget_Click(object sender, EventArgs e)
        {
            //1.0 确定url  网络爬虫（蜘蛛）
            string url = "http://localhost:31058/api/Values/GetPig";

            //2.0 利用c#代码模拟浏览器发出请求(get,post)
            WebRequest request = WebRequest.Create(url);
            request.Method = "get"; //如果不设置，默认就是get请求
            //获取响应报文
            WebResponse response = request.GetResponse();
            //获取响应报文体的字节数据byte[]
            System.IO.Stream responseBody = response.GetResponseStream();

            //将responseBody 字节数组转换成字符串
            using (System.IO.StreamReader sr = new System.IO.StreamReader(responseBody))
            {
                //将当前响应报文体转换成字符串 ，按照webapi的目前写法：[{"Name":"八戒","Age":500},{"Name":"小猪","Age":1}]
                string resposneBodyText = sr.ReadToEnd();

                //利用json序列化器将json字符串反序列化成ResponseEntity集合
                System.Web.Script.Serialization.JavaScriptSerializer jsoner = new System.Web.Script.Serialization.JavaScriptSerializer();
                //调用泛型方法，直接将json字符串反序列成list集合
                List<ResponseEntity> list = jsoner.Deserialize<List<ResponseEntity>>(resposneBodyText);

                rpdata.DataSource = list;
                rpdata.DataBind();
            }
        }

        public class ResponseEntity
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}