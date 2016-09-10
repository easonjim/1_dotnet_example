using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgressBar
{
    class Program
    {
        static void Main(string[] args)
        {
            bar();
        }

        //模拟进度条方法
        public static void bar()
        {
            //显示提示信息
            Console.SetCursorPosition(32, 20);
            Console.WriteLine("程序正在载入请等");
            //显示进度条
            for (int i = 0; i <= 100; i++)
            {
                Console.SetCursorPosition(38, 21);
                Console.WriteLine("{0}%", i);
                Console.SetCursorPosition(13, 22);
                Console.WriteLine("┃");
                Console.SetCursorPosition(15, 22);
                Console.WriteLine(new string('*', (i / 2) + 2));
                Console.SetCursorPosition(65, 22);
                Console.WriteLine("┃");
                Thread.Sleep(50);
            }
            //显示提示信息
            Console.SetCursorPosition(34, 23);
            Console.WriteLine("程序载入完成");
            Thread.Sleep(1000);
            //清屏
            Console.Clear();
        }
    }
}
