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

            bool[] b = Sticks.Roll();
            int number = Sticks.GetNumber();
            int i = 0;
            Console.WriteLine("\n");
            while (i != 4)
            {
                Console.Write(b[i] + " ");
                i++;
            }
            Console.WriteLine("\n" + number);

            Console.ReadLine();
        }
    }
}
