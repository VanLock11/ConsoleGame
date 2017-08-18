using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleGame
{
    class Hero
    {
        private char chHero = '*';
        private int x = Console.WindowWidth / 2, y = Console.WindowHeight / 2;
        public int X
        {
            set
            {
                if (value < Console.WindowWidth && value >= 0)
                    x = value;
                else if (value < 0)
                {
                    x = Console.WindowWidth - 1;
                }
                else if (value == Console.WindowWidth)
                {
                    x = 1;
                }

            }
            get
            {
                return x;
            }
        }
        public int Y
        {
            set
            {
                if (value < Console.WindowHeight && value >= 0)
                    y = value;
                else if (value < 0)
                {
                    y = Console.WindowHeight - 1;
                }
                else if (value == Console.WindowHeight)
                {
                    y = 0;
                }

            }
            get
            {
                return y;
            }
        }

        public Hero()
        {
            //Defout contsructor
        }

        //Display function
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(chHero);
        }

        //Control function and coordinate measurement
        public void Control()
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        X--;
                        break;
                    case ConsoleKey.RightArrow:
                        X++;
                        break;
                    case ConsoleKey.UpArrow:
                        Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        Y++;
                        break;

                }
              
            }
        }



    }



}
