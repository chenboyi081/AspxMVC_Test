using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace C062CallAPI
{
    public partial class StaticPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 静态化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btOk_Click(object sender, EventArgs e)
        {
            //1.0 构造webrequest
            WebRequest requet = WebRequest.Create("http://localhost:31071/getdata.aspx");

            WebResponse resposne = requet.GetResponse();
            Stream stream = resposne.GetResponseStream();
            string txt;
            using (StreamReader sr = new StreamReader(stream))
            {
                txt = sr.ReadToEnd(); //html的内容

                string filename = Guid.NewGuid().ToString() + ".html";
                //将txt存入磁盘的html文件中即可
                File.WriteAllText(Server.MapPath("/staticPage/" + filename), txt);
            }
        }
    }
}