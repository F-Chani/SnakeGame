using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Program
    {

        static void Main(string[] args)
        {
           
            Snake snake = new Snake();
            //הדפסת המסגרת
            Console.BackgroundColor = ConsoleColor.Cyan;
            for (int i = 0; i <= 28; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(" ");
                Console.SetCursorPosition(70, i);
                Console.WriteLine(" ");
            }
            for (int i = 0; i <= 70; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine(" ");
                Console.SetCursorPosition(i, 28);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            snake.CreatePositionsList();



















            Console.ReadKey();  
        }
    }
}
