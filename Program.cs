using System;

namespace AShittybot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot shittybot = new Bot();

            shittybot.Connect(true);

            Console.ReadLine();

            shittybot.Disconect();

        }
    }
}

