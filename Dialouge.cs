using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Funny_Project
{
    public partial class Dialouge
    {
        public string starting_npc_name = "Jackass";
        public string dialouge;
        public string player_name;
        
        public void Starting_NPC ()
        {
            
            Dialouge_sequence($"{starting_npc_name}: Hello, traveler!");
            Dialouge_sequence($"{starting_npc_name}: It seems you finally awake");
            Dialouge_sequence($"{starting_npc_name}: By the way what is your name");

            string input_name = Player.Players_Name();
            Player player = new Player(input_name);

            Dialouge_sequence($"{starting_npc_name}: Hmm, {player.Name} what a nice name.");
            Dialouge_sequence($"{starting_npc_name}: So {player.Name} where are you heading to right now?");

        }

        public void Dialouge_sequence(string Dialouge_text)
        {
            Console.Clear();
            dialouge = Dialouge_text;
            PrintAnimated(dialouge, 50, true);

            // Get the line just after the animated text
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
            int leftPadding = 0; // Align to the left edge

            // Set cursor to the last line
            Console.SetCursorPosition(leftPadding, windowHeight - 1);
            Console.WriteLine(text);
        }

        public void WriteAtBottom(string text)
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int textLength = text.Length;
            int leftPadding = Math.Max((windowWidth - textLength) / 2, 0);

            // Set cursor to the last line
            Console.SetCursorPosition(leftPadding, windowHeight - 1);
            Console.WriteLine(text);
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
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
    }
}
