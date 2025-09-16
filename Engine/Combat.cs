using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funny_Project.Player_Data;

namespace Funny_Project.Engine
{
    internal class Combat
    {
        
        private List<Entity> mobs;
        private Player player;

        public Combat(Player player, List<Entity> mobs)
        {
            this.player = player;
            this.mobs = mobs;
            
        }

        public void StartBattle()
        {
            Console.WriteLine("⚔️ Battle Start! ⚔️");

            while (player.player_entity.Health > 0 && mobs.Any(m => m.Health > 0))
            {
                // ---- Player Turn ----
                Console.WriteLine("\nYour turn! Select which mob to attack:");
                for (int i = 0; i < mobs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {mobs[i].Info()}");
                }

                Console.Write(": ");
                string option = Console.ReadLine();

                if (int.TryParse(option, out int choice) && choice >= 1 && choice <= mobs.Count)
                {
                    Entity selectedMob = mobs[choice - 1];
                    player.Attack(selectedMob);
                }
                else
                {
                    Console.WriteLine("Invalid input. Turn skipped!");
                }

                // ---- Mobs' Turn ----
                foreach (var mob in mobs)
                {
                    if (mob.Health > 0)
                    {
                        mob.Attack(player);
                    }
                }
            }

            // ---- Battle End ----
            if (player.Health <= 0)
                Console.WriteLine("💀 You were defeated!");
            else
                Console.WriteLine("🎉 You won the battle!");
        }
    }
}
