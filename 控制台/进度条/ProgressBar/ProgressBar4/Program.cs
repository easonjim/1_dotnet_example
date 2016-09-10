using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressBar4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Loading assets: ");
            for (int i = 0; i <= 100; i++)
            {
                drawTextProgressBar(i, 100, 50, 15);
                Thread.Sleep(50);
            }
            Console.WriteLine('\n');

            Console.Write("Loading scripts: ");
            for (int i = 0; i <= 100; i++)
            {
                drawTextProgressBar(i, 100, 30, 15, ConsoleColor.Red);
                Thread.Sleep(50);
            }
            Console.WriteLine('\n');

            Console.Write("Loading nothing: ");
            for (int i = 0; i <= 100; i++)
            {
                drawTextProgressBar(i, 100, 100, 15, ConsoleColor.Blue);
                Thread.Sleep(50);
            }

            Console.Read();
        }

        private static void drawTextProgressBar(int progress, int total, int barLength = 30, int left = 0, ConsoleColor color = ConsoleColor.Green)
        {
            char loadCchar = ' ';
            Console.CursorLeft = left;
            Console.Write("[");
            Console.CursorLeft = barLength + left + 1;
            Console.Write("]");
            Console.CursorLeft = 1 + left;
            var step = ((double)barLength / total);

            //draw filled part
            int position = 1;
            for (int i = 0; i < step * progress; i++)
            {
                Console.BackgroundColor = color;
                Console.CursorLeft = left + position++;
                Console.Write(loadCchar);
            }

            //draw unfilled part
            for (int i = position; i <= barLength; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = left + position++;
                Console.Write(loadCchar);
            }

            //draw totals
            Console.CursorLeft = left + barLength + 4;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress * 100 / total + "%    ");
        }
    }
}
