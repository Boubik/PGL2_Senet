using System;

namespace plg2_senet
{
    class Program
    {
        static void Main(string[] args)
        {
            //color output (dosnt work on windows. cmd dosnt support ANSI escape codes)
            bool color = true;

            Game CZgame = new Game(5, color);
            Render.PrintArray(CZgame);
            Console.ReadLine();
        }
    }
}
