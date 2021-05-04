using System;

namespace plg2_senet
{
    class Program
    {
        static void Main(string[] args)
        {
            Game daCZgame = new Game(5);
            Render.PrintArray(daCZgame);
            Console.ReadLine();
        }
    }
}
