using System;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.Greet();

            do
            {
                g.Display();
                g.Ask();
                if (g.DidLose())
                {
                    g.Display();
                    g.PrintColorMessage(ConsoleColor.Magenta, "Oh no! The UFO just flew away with another person!");
                    break;
                }
                else if (g.DidWin())
                {
                    g.Display();
                    g.PrintColorMessage(ConsoleColor.Magenta, "Hooray! You saved the person and earned a medal of honor!");
                    break;
                }
            } while (true);

        }
    }
}
