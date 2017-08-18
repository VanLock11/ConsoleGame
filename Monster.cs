using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Monster
    {
        private Random rd = new Random();
        private char chMonster = 'f';

        private int x, y;
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
        public Monster()
        {
            //Defout constructor
        }

        //Display function
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(chMonster);
        }


    }
}
