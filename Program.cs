using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameControler gc = new GameControler();
            Thread t = new Thread(new ThreadStart(gc.GameOver));
            t.Start();
            gc.Run();
        }
    }
}
