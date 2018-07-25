using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APeiceOfChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board game = new Board();
            game.Init();
            game.Print();
            Console.ReadKey();
        }
    }
}
