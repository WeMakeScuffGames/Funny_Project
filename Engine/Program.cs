

using Funny_Project.Battles;
using Funny_Project.Player_Data;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Funny_Project.Engine
{
    internal class Program : GmaeWorkings
    {
        private static void Main(string[] args)
        {

            WriteCentered("-=Welcom to XXXXX=-");

            WriteCentered("-=Press any key to start=-");
            while (true)
            {
                var input = Console.ReadKey(true);
                if (input.Key != ConsoleKey.Escape)
                {
                    Console.Clear();
                    WriteAtBottom("Starting. . .");
                    loading();

                    Main_menu();
                    break;
                }
                else
                {
                    Console.WriteLine("huh???");
                }
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

            static void WriteAtBottom(string text)
            {
                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;
                int textLength = text.Length;
                int leftPadding = Math.Max((windowWidth - textLength) / 2, 0);

                // Set cursor to the last line
                Console.SetCursorPosition(leftPadding, windowHeight - 1);
                Console.WriteLine(text);
            }


            static void loading()
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
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

            static void Main_menu()
            {
                var game = new GmaeWorkings();

                menu_options_display();

                while (true)
                {
                    var keypress = Console.ReadKey(true);
                    switch (keypress.Key)
                    {
                        case ConsoleKey.D1:
                            
                            game.New_Game();

                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("\nContinuing game...");

                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("\nOpening settings...");

                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Showing credits...");
                            Credits();
                            menu_options_display();
                            break;
                        case ConsoleKey.D5:
                            loading();
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid selection. Please choose 1-5.");
                            break;
                    };
                }
            }
        }
    }
}