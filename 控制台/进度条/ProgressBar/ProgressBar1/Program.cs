using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgressBar1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool  isBreak  =   false ;
             ConsoleColor colorBack  =  Console.BackgroundColor;
             ConsoleColor colorFore  =  Console.ForegroundColor;
 
              // 第一行信息 
             Console.WriteLine( " *********** jinjazz now working...****** " );
 
              // 第二行绘制进度条背景 
             Console.BackgroundColor  =  ConsoleColor.DarkCyan;
              for  ( int  i  =   0 ;  ++ i  <=   25 ; )
              {
                 Console.Write( "   " );
             } 
             Console.WriteLine( "   " );
             Console.BackgroundColor  =  colorBack;
 
              // 第三行输出进度 
             Console.WriteLine( " 0% " );
              // 第四行输出提示,按下回车可以取消当前进度 
             Console.WriteLine( " <Press Enter To Break.> " );
 
              // -----------------------上面绘制了一个完整的工作区域,下面开始工作
 
              // 开始控制进度条和进度变化 
              for  ( int  i  =   0 ;  ++ i  <=   100 ; )
              {
                  // 先检查是否有按键请求,如果有,判断是否为回车键,如果是则退出循环 
                  if  (Console.KeyAvailable  &&  System.Console.ReadKey( true ).Key ==  ConsoleKey.Enter)
                  {
                     isBreak  =   true ;
                      break ;
                 } 
                  // 绘制进度条进度 
                 Console.BackgroundColor  =  ConsoleColor.Yellow; // 设置进度条颜色 
                 Console.SetCursorPosition(i / 4 ,  1 ); // 设置光标位置,参数为第几列和第几行 
                 Console.Write( "   " ); // 移动进度条 
                 Console.BackgroundColor  =  colorBack; // 恢复输出颜色
                  // 更新进度百分比,原理同上. 
                 Console.ForegroundColor  =  ConsoleColor.Green;
                 Console.SetCursorPosition( 0 ,  2 );
                 Console.Write( " {0}% " , i);
                 Console.ForegroundColor  =  colorFore;
                  // 模拟实际工作中的延迟,否则进度太快 
                 System.Threading.Thread.Sleep( 100 );
             } 
              // 工作完成,根据实际情况输出信息,而且清楚提示退出的信息 
             Console.SetCursorPosition( 0 ,  3 );
             Console.Write(isBreak  ?   " break!!! "  :  " finished. " );
             Console.WriteLine( "                        " );
              // 等待退出 
             Console.ReadKey( true );
         
        }
    }
}
