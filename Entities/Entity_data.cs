using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funny_Project.Dialouges;

namespace Funny_Project.Player_Data
{
    public partial class Entity(string name, float damage, float Health, float speed, int level)
    {
        public int Current_XP { get; set; } = 0;
        public int Max_XP { get; set; } = 50;
        public void Leveling_system(float current_xp, float max_xp)
        {
            

            if (current_xp == max_xp)
            {
                level++;
                current_xp = 0;
                max_xp += 100;
                damage += 5;
                Health += 20;
                speed += 0.5f;
                max_xp = 100 + max_xp * (level / 2f);

            } 
            else if (current_xp > max_xp) //xp overflow
            {
                
            }
        }

        //Enemies

        public static Entity CreateSlime()
        {
            var slime = new Entity("Slime", 3f, 30f, 0.8f, 1);
            slime.Max_XP = 50;
            return slime;
        }
        public static Entity CreateOrc()
        {
            var orc = new Entity("Orc", 10f, 80f, 1.2f, 1);
            orc.Max_XP = 75;
            return orc;
        }

        public static Entity CreateOgre()
        {
            var ogre = new Entity("Ogre", 18f, 150f, 0.9f, 1);
            ogre.Max_XP = 100;
            return ogre;
        }


        // ---------- Unique Mob Skills ----------
        public void SlimeSkill()
        {
            string dialougetxt = $"{name} splits into two smaller slimes!";
            Health /= 2; // reduces health when splitting
            damage /= 2; // smaller slime does less damage
        }

        public void OrcSkill()
        {
            Console.WriteLine($"{name} enters Berserk Mode!");
            damage *= 1.5f; // increase damage temporarily
            speed *= 0.8f;  // but slower
        }

        public void OgreSkill()
        {
            Console.WriteLine($"{name} smashes the ground, stunning enemies!");
            damage += 10;  // adds bonus damage for the attack
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        public Entity player_entity;
        public Player(string name)
        {
            Name = name;
            player_entity = new Entity(name, 10f, 100f, 5f, 1);
        }
        public static string Players_Name()
        {
            Dialouge dialouge = new Dialouge();

            dialouge.WriteAtBottom("Enter Your name: ");
            string p_name = Console.ReadLine();
            return p_name;
        }
    }
}
