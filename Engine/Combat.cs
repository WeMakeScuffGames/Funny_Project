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
            Console.Clear();
            Console.WriteLine("Battle Start!");

            while (player.player_entity.Health > 0 && mobs.Any(m => m.Health > 0))
            {
                // ---- Player Turn ----

                Console.WriteLine($"\n{player.Info()}");
                Console.WriteLine($" Skill Points: {player.SkillPoints}/{Player.MaxSkillPoints}");
                Console.WriteLine("\nYour turn! Choose an action:");
                Console.WriteLine("1. Basic Attack");
                Console.WriteLine("2. Skill");
                Console.WriteLine("3. Heal");

                Console.Write(": ");
                string actionChoice = Console.ReadLine();

                bool playerDidAttack = false;

                if (actionChoice == "1") // Basic Attack
                {
                    Console.WriteLine("\nSelect which mob to attack:");
                    for (int i = 0; i < mobs.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {mobs[i].Info()}");
                    }

                    Console.Write(": ");
                    string option = Console.ReadLine();

                    if (int.TryParse(option, out int choice) && choice >= 1 && choice <= mobs.Count)
                    {
                        Entity selectedMob = mobs[choice - 1];
                        player.BasicAttack(selectedMob);
                        playerDidAttack = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Turn skipped!");
                    }
                }
                else if (actionChoice == "2") // Skill
                {
                    if (player.SkillPoints > 0)
                    {
                        Console.WriteLine("\nSelect which mob to attack:");
                        for (int i = 0; i < mobs.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {mobs[i].Info()}");
                        }

                        Console.Write(": ");
                        string option = Console.ReadLine();

                        if (int.TryParse(option, out int choice) && choice >= 1 && choice <= mobs.Count)
                        {
                            Entity selectedMob = mobs[choice - 1];
                            player.SkillAttack(selectedMob);
                            playerDidAttack = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Turn skipped!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have no Skill Points! Defaulting to Basic Attack.");
                    }
                }
                else if (actionChoice == "3") // Heal
                {
                    player.Heal();
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
                        Console.Clear();
                        mob.Attack(player);
                        mob.Attack(player.player_entity);
                        Console.WriteLine($"{player.Info()}");
                    }
                }
            }

            // ---- Battle End ----
            if (player.player_entity.Health <= 0)
                Console.WriteLine("You were defeated!");
            else
                Console.WriteLine("You won the battle!");
        }
    }
}
