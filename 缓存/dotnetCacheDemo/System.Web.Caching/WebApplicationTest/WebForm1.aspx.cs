using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static readonly Cache WebCache = HttpRuntime.Cache;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebCache.Insert("test",DateTime.Now.ToString());
            }
        }


        protected void button1_Click(object sender, EventArgs e)
        {
            Response.Write(WebCache["test"].ToString());
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            WebCache.Insert("test1", DateTime.Now.ToString());

        }

        protected void button3_Click(object sender, EventArgs e)
        {
            Response.Write(WebCache["test1"].ToString());
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            Cache webCache1 = HttpRuntime.Cache;
            Response.Write(webCache1["test"].ToString());
        }

        protected void button5_Click(object sender, EventArgs e)
        {
            Cache webCache1 = HttpRuntime.Cache;
            //再进行设置全局变量的值，然后再次点击上面按钮获取，发现全局实例的缓存值会改变
            webCache1.Insert("test", "abc2");
        }

        protected void button6_Click(object sender, EventArgs e)
        {
            IDictionaryEnumerator enumerator = WebCache.GetEnumerator();
            Dictionary<string, object> list = new Dictionary<string, object>();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Key.ToString(), enumerator.Value);
            }
            Response.Write(string.Concat(string.Join(",", list.Keys), "-", string.Join(",", list.Values)));
        }



    }
}