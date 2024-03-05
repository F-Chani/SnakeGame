using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    internal class Snake
    {
        public List<Location> snake { get; set; } = new List<Location>();
        public Location Food { get; set; } = new Location(7, 30);

       
        //מאתחל את הנחש בהתחלה
        public void CreatePositionsList()
        {
            int count = 0;
            snake.Add(new Location(1, 1));
            snake.Add(new Location(2, 1));
            snake.Add(new Location(3, 1));
            snake.Add(new Location(4, 1));


            foreach (var item in snake)
            {
                Console.SetCursorPosition(item.Col, item.Row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('$');
            }
            FoodPlace();//התחלה של האוכל
            Play(ref count);
        }
        #region בדיקות תקינות
        //פונקציה שבודקת שהנחש לא נתקע בעצמו
        public bool Checkisnotstukinhisself(int col, int row)
        {
            foreach (var item in snake)
            {
                if (item.Row == col && item.Col == row)
                {
                    GameOver();
                    return false;//לשלוח לפונקציה של game over
                }
            }
            return true;
        }
        //פונקציה שבודקת שהנחש לא נתקע בקצוות של המסגרת
        public bool Checkisnotstukinframe(int col, int row)
        {
            if (row == 0 || col == 0 || row == 70 || col == 28)
            {
                GameOver();
                return false;//לשלוח לפונקציה של game over
            }
            return true;
        }
        //פונקציה של סיום המשחק היא מוחקת את כל הלוח ומדפיסה game over
        public void GameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            while (true)
            {
                Console.SetCursorPosition(20, 25);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("game-over");
                Thread.Sleep(300);
                Console.SetCursorPosition(20, 20);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("game-over");
                Thread.Sleep(300);
                Console.SetCursorPosition(20, 15);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("game-over");
                Thread.Sleep(300);
                Console.SetCursorPosition(20, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("game-over");
                Thread.Sleep(300);
                Console.SetCursorPosition(20, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("game-over");
                Thread.Sleep(300);
                Console.SetCursorPosition(20,0);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("game-over");
                Thread.Sleep(300);
                Console.Clear();
            }

        }
        #endregion

        //מיקום של האוכל כולל בדיקת תקינות
        public void FoodPlace()
        {
            bool flag = true;
            while (flag)
            {
                Random rand = new Random();
                Food.Row = rand.Next(1, 27);
                Food.Col = rand.Next(1, 69);
                Console.Beep();
                for (int i = 0; i < snake.Count; i++)
                {
                    if (Food.Row == snake[i].Row && Food.Col == snake[i].Col)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                       
                }
            }
            PrintChar('X', Food);
        }
        //מדפיס את התו 
        public void PrintChar(char ch, Location place)
        {
            Console.SetCursorPosition(place.Col, place.Row);
            switch (ch)
            {
                case '$':
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    break;
            }
            Console.WriteLine(ch);
        }
        //בודק אם הנחש הגיע לאוכל 
        public bool IfTheFoodEaten(int col, int row, Location Food,ref int count)
        {
            if (row == Food.Col && col == Food.Row)
            {
                count += 10;
                Console.SetCursorPosition(83, 7);
                Console.WriteLine("points:"+count);
                return true;
            }
               
            return false;
        }
        //פונקציה שאחראית על התנהלות הנחש 
        public bool GoSnake(int col, int row,ref int count)
        {
            bool IsnotValid=Checkisnotstukinhisself(col, row);
            IsnotValid=Checkisnotstukinframe(col, row);
            if (!IsnotValid)
                return false;
            bool flag = true;
            flag = IfTheFoodEaten(col, row, Food,ref count);//בודק אם הנחש אכל

            if (flag)
            {
                snake.Add(new Location(Food.Col, Food.Row));//הוספת איבר לנחש
                PrintChar('$', Food);//מאריך את הנחש במסך
                FoodPlace();//שולח לפונקציה שמיצרת אוכל חדש 
            }
            else
            {
                PrintChar(' ', snake[0]);
                snake.RemoveAt(0);
                snake.Add(new Location(row, col));
                PrintChar('$', snake[snake.Count-1]);

            }
            return true;

        }
        // הפונקציה מקבלת קלט של מקש ולפי המקש הוא יודע לשלוח את המיקום הבא שאמור להתווסף לנחש בפונקציה של הולכת נחש  
        public void Play(ref int count)
        {
            Console.SetCursorPosition(80,3);
            Console.WriteLine("press level 1,2,3");
            Console.SetCursorPosition(80, 5);
            int y = int.Parse(Console.ReadLine());
            int level = 180;
            if (y == 1)
                level = 180;
            else if(y==2)
                level = 100;
            else
                level = 60;
            // snake.SnakeMain();פונקציה שתשלח לפונקציה שתדפיס את הלוח תיצור את האוכל ואת הנחש בעצמו
            ConsoleKey key = ConsoleKey.RightArrow;
            while (true)
            {
                Thread.Sleep(level);
                if (Console.KeyAvailable)
                    key = Console.ReadKey(true).Key;
                switch (key)
                {
                    
                    case ConsoleKey.RightArrow:
                        if (!GoSnake(snake[snake.Count() - 1].Row, snake[snake.Count() - 1].Col + 1,ref count))
                            return;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (!GoSnake(snake[snake.Count() - 1].Row, snake[snake.Count() - 1].Col - 1, ref count))
                            return;
                        break;
                    case ConsoleKey.UpArrow:
                        if (!GoSnake(snake[snake.Count() - 1].Row-1, snake[snake.Count() - 1].Col, ref count))
                            return;
                        break;
                    case ConsoleKey.DownArrow:
                        if (!GoSnake(snake[snake.Count() - 1].Row+1, snake[snake.Count() - 1].Col, ref count))
                            return;
                        break;
                }
            }
        }
    }
}
