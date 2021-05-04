using System;

namespace plg2_senet
{
    class Program
    {
        static void Main(string[] args)
        {
            bool color = true;

            Game CZgame = new Game(5, color);
            Render.PrintArray(CZgame);
            Console.ReadLine();
        }
    }
}
