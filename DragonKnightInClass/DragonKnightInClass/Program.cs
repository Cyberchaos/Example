using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonKnightInClass
{

    class Program
    {
        static void Main(string[] args)
        {

            GameEngine engine = new GameEngine();
            for (int k = 0; k < 1000000; k++)
            {
                engine.playGame();
            }
            Console.WriteLine("Dragon wins: " + engine.DragonWins);
            Console.WriteLine("Knight wins: " + engine.KnightsWins);

        }
    }
}
