﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplicationTest
{
    public partial class Form1 : Form
    {
        //没创建一个实例就是一个缓存，key可以相同，其中缓存的过期时间可以根据config进行配置
        //注意：add方法只能第一次增加，以后的值都不能改变，改用set能做到更新
        private static readonly MemoryCache MemoryCache = new MemoryCache("Easemob.Restfull4Net");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(6);
            MemoryCache.Set(new CacheItem("test", DateTime.Now.ToString()), policy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MemoryCache["test"].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(6);
            MemoryCache.Set("test1",DateTime.Now.ToString(), policy);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MemoryCache["test1"].ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MemoryCache memoryCache1 = new MemoryCache("Easemob.Restfull4Net");
            //以下的值为空，可以看出MemoryCache变重新创建了，相当于一个新的
            MessageBox.Show(memoryCache1["test"].ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MemoryCache memoryCache1 = new MemoryCache("Easemob.Restfull4Net");
            //再进行设置全局变量的值，然后再次点击上面按钮获取，发现全局实例的缓存值不会改变
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(6);
            memoryCache1.Set(new CacheItem("test", "abc2"), policy);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> list = new Dictionary<string, object>();
            foreach (var enumerator in MemoryCache)
            {
                list.Add(enumerator.Key.ToString(), enumerator.Value);
            }
            MessageBox.Show(string.Concat(string.Join(",", list.Keys), "-", string.Join(",", list.Values)));
        }

    }
}
