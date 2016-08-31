using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Windows.Forms;

namespace WindowsFormsApplicationTest
{
    public partial class Form1 : Form
    {
        
        private static readonly Cache WebCache = HttpRuntime.Cache;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebCache.Insert("test", DateTime.Now.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(WebCache["test"].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebCache.Insert("test1", DateTime.Now.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(WebCache["test1"].ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cache webCache1 = HttpRuntime.Cache;
            //以下的值不为空，可以看出还是原来的
            MessageBox.Show(webCache1["test"].ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cache webCache1 = HttpRuntime.Cache;
            //再进行设置全局变量的值，然后再次点击上面按钮获取，发现全局实例的缓存值会改变
            webCache1.Insert("test", "abc2");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IDictionaryEnumerator enumerator = WebCache.GetEnumerator();
            Dictionary<string, object> list = new Dictionary<string, object>();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Key.ToString(), enumerator.Value);
            }
            MessageBox.Show(string.Concat(string.Join(",", list.Keys),"-",string.Join(",",list.Values)));
        }


    }
}
