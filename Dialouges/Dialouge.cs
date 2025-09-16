using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funny_Project.Battles;
using Funny_Project.Engine;
using Funny_Project.Player_Data;
using static System.Net.Mime.MediaTypeNames;

namespace Funny_Project.Dialouges
{
    public partial class Dialouge
    {
        public string starting_npc_name = "Bizzn The Merchant";
        public string dialouge;
        public string player_name;

        public void Starting_NPC()
        {
            string[] dialogues = new[]
            {
                $"{starting_npc_name}: Hello, traveler!",
                $"{starting_npc_name}: It seems you finally awake",
                $"{starting_npc_name}: By the way what is your name",
                $"{starting_npc_name}: Hmm, {{player_name}} what a nice name.",
                $"{starting_npc_name}: {{player_name}} we have been ambush",
                ""
            };

            Player player = null;
            


            for (int i = 0; i < dialogues.Length; i++)
            {
                if (i == 3) // "By the way what is your name"
                {
                    string input_name = Player.Players_Name();
                    player = new Player(input_name);
                }
                else if (i == 5) 
                {
                    First_battle first_Battle = new First_battle(player);
                    first_Battle.Start();
                    Credits();
                    menu_options_display();
                    break;
                }
                
                string line = dialogues[i];

                // Replace placeholder after player is created
                if (player != null)
                {
                    line = line.Replace("{player_name}", player.Name);
                }

                dialouge = line;
                Dialouge_sequence(dialouge);
            }
        }

        public void Dialouge_sequence(string Dialouge_text)
        {
            Console.Clear();
            dialouge = Dialouge_text;
            PrintAnimated(dialouge, 50, true);

            // Log the displayed dialogue
            LogDialogue(dialouge);

            int animationLine = Console.CursorTop;
            Dialouge_animation(animationLine);

            Console.ReadKey(true);
        }

        public void Dialouge_animation(int line)
        {
            string[] frames = { "|", "/", "-", "\\" };
            int frameIndex = 0;
            int animationSpeed = 100; // milliseconds

            Console.CursorVisible = false; // Hide the cursor

            while (!Console.KeyAvailable) // Loop until a key is pressed
            {
                Console.SetCursorPosition(0, line); // Set cursor to the desired line
                Console.Write(frames[frameIndex] + " Press any key to continue...");
                frameIndex = (frameIndex + 1) % frames.Length;
                Thread.Sleep(animationSpeed);
            }

            // Clear the animation line after exit
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.CursorVisible = true; // Show the cursor again
        }

        public void WriteAtBottomLeft(string text)
        {
            int windowHeight = Console.WindowHeight;
            int textLength = text.Length;
            int leftPadding = 0;
            Console.SetCursorPosition(leftPadding, windowHeight - 1);
            Console.WriteLine(text);
        }

        public void WriteAtBottom(string text)
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int textLength = text.Length;
            int leftPadding = Math.Max((windowWidth - textLength) / 2, 0);
            Console.SetCursorPosition(leftPadding, windowHeight - 1);
            Console.WriteLine(text);
        }

        static void WriteCentered(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int leftPadding = Math.Max((windowWidth - textLength) / 2, 0);
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
            Console.WriteLine();
        }


        public static void PrintAnimated(string text, int delayMs = 30, bool atBottom = false)
        {
            if (atBottom)
            {
                // Move cursor to the bottom before printing
                int windowHeight = Console.WindowHeight;
                int leftPadding = 0;
                Console.SetCursorPosition(leftPadding, windowHeight - 1);
            }

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
        private static void LogDialogue(string text)
        {
            string logFilePath = "TextLogs.txt";
            using (var writer = new StreamWriter(logFilePath, append: true))
            {
                writer.WriteLine(text);
            }
        }

        static void Credits()
        {
            Console.Clear();
            for (int i = 0; i < 100; i++)
            {
                WriteCentered("Just Iniw");
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true); // Clear the key
                    break; // Exit the credits early if a key is pressed
                }
                Thread.Sleep(500);
            }
        }
        static void menu_options_display()
        {
            Console.Clear();
            WriteCentered("-=Main Menu=-\n");
            WriteCentered("1. New Game");
            WriteCentered("2. Continue");
            WriteCentered("3. Settings");
            WriteCentered("4. Credits");
            WriteCentered("5. Exit");
        }
    }
}
