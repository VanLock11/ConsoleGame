using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleGame
{
    class GameControler
    {

        private List<Monster> monster_list = new List<Monster>();
        private Random rd = new Random();
        private Hero hero = new Hero();
        private bool gameOver = false;
        public GameControler()
        {
            Console.CursorVisible = false;
            ListCreate();
        }

        //Moves the Monster's position
        private void MoveMonster()
        {
            while (!gameOver)
            {


                foreach (Monster m in monster_list)
                {



                    if (m.Y > hero.Y)
                    { m.Y--; }
                    else if (m.Y < hero.Y)
                    {
                        m.Y++;
                    }

                    Thread.Sleep(70);
                    if (m.X > hero.X)
                    {
                        m.X--;
                    }
                    else if (m.X < hero.X)
                    {
                        m.X++;
                    }

                }
            }
        }

        //Creation of coordinates with the condition of range
        private void CreateCordinats(Monster k)
        {
            do
            {
                k.X = rd.Next(1, Console.WindowWidth - 1);
                k.Y = rd.Next(1, Console.WindowHeight - 1);
            } while (k.X + k.Y - hero.X - hero.Y < 20);
        }

        // Creature List of random size
        private void ListCreate()
        {
            int size = rd.Next(1, 3);
            for (int i = 0; i < size; i++)
            {
                Monster monster = new Monster();

                CreateCordinats(monster);
                foreach (Monster t in monster_list)
                {
                    while (monster.X == t.X || monster.Y == t.Y)
                    {
                        CreateCordinats(monster);
                    }

                }
                monster_list.Add(monster);
            }
        }

        //Set of main functions
        public void Run()
        {

            Thread t_MoveMonster = new Thread(new ThreadStart(MoveMonster));
            Thread t_HeroControl = new Thread(new ThreadStart(hero.Control));
            t_HeroControl.Start();
            t_MoveMonster.Start();
            while (true)
            {
                if (gameOver == true)
                {
                    t_HeroControl.Abort();
                    t_MoveMonster.Abort();
                    break;
                }

                Console.Clear();
                foreach (Monster m in monster_list)
                {
                    m.Draw();
                }

                hero.Draw();
                Thread.Sleep(50);


            }
        }

        // Function of checking the final game
        public void GameOver()
        {
            while (!gameOver)
            {
                foreach (Monster m in monster_list)
                {
                    if (m.X == hero.X && m.Y == hero.Y)
                    {
                        gameOver = true;
                        break;
                    }
                }
            }
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - 12) / 2, Console.WindowHeight / 2);
            Console.WriteLine("Game Over!!!");
        }

    }
}
