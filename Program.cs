

using System.ComponentModel;
using System.ComponentModel.Design;

namespace Funny_Project
{
    internal class Program : Funny_Project.GmaeWorkings
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("-=   Welcom to XXXXX   =-");

            Console.WriteLine("\n\n-=   Press any key to start   =-");
            while (true)
            {
                var input = Console.ReadKey(true);
                if (input.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine("             Starting...\n");
                    loading();
                    Main_menu();
                    break;
                }
                else
                {
                    Console.WriteLine("huh???");
                }
            }
            
            static void loading()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    System.Threading.Thread.Sleep(500);
                }
            }

            static void Credits()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("\nJust Iniw ");
                    if (Console.KeyAvailable)
                    {
                        Console.ReadKey(true); // Clear the key
                        break; // Exit the credits early if a key is pressed
                    }
                    System.Threading.Thread.Sleep(500);
                }
            }

            static void menu_options_display() 
            {
                Console.WriteLine("\n         -=Main Menu=-\n");
                Console.WriteLine("         1. New Game \n");
                Console.WriteLine("         2. Continue \n");
                Console.WriteLine("         3. Settings \n");
                Console.WriteLine("         4. Credits \n");
                Console.WriteLine("         5. Exit \n");
            }

            static void Main_menu ()
            {
                var game = new GmaeWorkings();

                menu_options_display();

                while (true)
                {
                    var keypress = Console.ReadKey(true);
                    switch (keypress.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("\nStarting a new game...");
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