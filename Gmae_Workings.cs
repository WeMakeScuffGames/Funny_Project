using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funny_Project.Dialouges;

namespace Funny_Project
{
    public partial class GmaeWorkings : Dialouge
    {

        public void New_Game()
        {
            var Dialouge = new Dialouge();
            Console.Clear();
            WriteAtBottomRight("Starting a New Game...");
            loading();
            Dialouge.Starting_NPC();
        }

        static void loading()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write(". ");
                System.Threading.Thread.Sleep(50);
            }
        }
        static void WriteAtBottomRight(string text)
        {
            int windowHeight = Console.WindowHeight;
            int textLength = text.Length;
            int leftPadding = 0; // Align to the left edge

            // Set cursor to the last line
            Console.SetCursorPosition(leftPadding, windowHeight - 1);
            Console.WriteLine(text);
        }

        public void Continue_Game()
        {
            Console.Clear();
            WriteAtBottomRight("Continuing your last game...");
            loading();
            // Load game logic here
        }
    }
}
