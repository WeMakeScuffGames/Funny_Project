using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny_Project
{
        internal class Player
        {

        // Property to store the player's name
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        //storing the name of the player
        public static string Players_Name()
            {
                Dialouge dialouge = new Dialouge();

                dialouge.WriteAtBottom("Enter Your name: ");
                string p_name = Console.ReadLine();
                return p_name;
            }
        }
}
