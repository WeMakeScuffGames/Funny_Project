using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funny_Project.Dialouges;

namespace Funny_Project.Player_Data
{
    public partial class Entity
    {
        public int Current_XP { get; set; } = 0;
        public int Max_XP { get; set; } = 50;

        public string Name { get; set; }
        public float Damage { get; set; }
        public float Health { get; set; }
        public float Speed { get; set; }
        public int Level { get; set; }

        public Entity(string name, float damage, float health, float speed, int level)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Speed = speed;
            Level = level;
        }

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

            Console.WriteLine($"{Name} attacked {target.Name}!");
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
            Console.WriteLine($"{Name} splits into two smaller slimes!");
            Health /= 2; // reduces health when splitting
            Damage /= 2; // smaller slime does less damage
        }

        public void OrcSkill()
        {
            Console.WriteLine($"{Name} enters Berserk Mode!");
            Damage *= 1.5f; // increase damage temporarily
            Speed *= 0.8f;  // but slower
        }

        public void OgreSkill()
        {
            Console.WriteLine($"{Name} smashes the ground, stunning enemies!");
            Damage += 10;  // adds bonus damage for the attack
        }

        // ---------------- Info ----------------
        public string Info()
        {
            return $"{Name} - HP: {Health}, DMG: {Damage}, LVL: {Level}";
        }

    }



    public class Player
    {
        public string Name { get; private set; }
        public float Health { get; set; }
        public int SkillPoints { get; private set; } = 2;
        public const int MaxSkillPoints = 5;

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
        public void BasicAttack(Entity target)
        {
            player_entity.Attack(target);
            if (SkillPoints < MaxSkillPoints)
                SkillPoints++;
        }

        public void SkillAttack(Entity target)
        {
            if (SkillPoints > 0)
            {
                SkillPoints--;
                float skillDamage = player_entity.Damage * 2f; // Example: double damage
                target.Health -= skillDamage;
                if (target.Health < 0) target.Health = 0;
                Console.WriteLine($"{Name} used a SKILL on {target.Name} for {skillDamage} damage!");
            }
            else
            {
                Console.WriteLine("❌ Not enough Skill Points!");
            }
        }

        public void Heal()
        {
            SkillPoints--;
            float healAmount = 25f;
            player_entity.Health += healAmount;
            Console.WriteLine($"{Name} healed for {healAmount} HP!");
        }

        public string Info()
        {
            return $"{Name} - HP: {player_entity.Health}, DMG: {player_entity.Damage}, LVL: {player_entity.Level}";
        }
    }
}
