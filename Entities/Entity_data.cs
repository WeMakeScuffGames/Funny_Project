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

        public string Name { get; set; }
        public float Damage { get; set; }
        public float Health { get; set; }
        public float Speed { get; set; }
        public int Level { get; set; }

        public void LevelUp(Entity targetMob)
        {
            if (targetMob.Health <= 0)
            {
                int expGain = targetMob.Level * 10;
                Current_XP += expGain;

                while (Current_XP >= Max_XP)
                {
                    Level++;
                    Current_XP = 0;
                    Damage += 5;
                    Health += 20;
                    Speed += 0.5f;
                    Max_XP = 100 + (int)(Max_XP * (Level / 2f)); // scaling formula

                    Console.WriteLine($"{Name} leveled up! Now Level {Level} (HP: {Health}, DMG: {Damage}, SPD: {Speed})");
                }
            }
        }

        // ---------------- Attack ----------------
        public string Attack(Entity targetMob)
        {
            targetMob.Health -= Damage;
            if (targetMob.Health < 0)
                targetMob.Health = 0;

            if (targetMob.Health == 0)
            {
                return $"{Name} defeated {targetMob.Name}!";
            }
            else
            {
                return $"{Name} attacked {targetMob.Name}. {targetMob.Name}'s health: {targetMob.Health}";
            }
        }
        public void Attack(Player target)
        {
            target.Health -= this.Damage;
            if (target.Health < 0) target.Health = 0;

            Console.WriteLine($"{Name} attacked {target.Name}! {target.Name}'s health: {target.Health}");
        }

        // ------------ Enemies --------------------

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

        // ---------------- Info ----------------
        public string Info()
        {
            return $"{Name} - HP: {Health}, DMG: {Damage}, LVL: {Level}, XP: {Current_XP}/{Max_XP}";
        }

    }



    public class Player
    {
        public string Name { get; private set; }
        public float Health { get; set; }

        public Entity player_entity { get; private set; }
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

        public void Attack(Entity target)
        {
            player_entity.Attack(target);
        }
    }
}
