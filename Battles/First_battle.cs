using Funny_Project.Engine;
using Funny_Project.Player_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny_Project.Battles
{
    internal class First_battle
    {
        private Combat combat;
        public First_battle(Player player) 
        {
            var slime = Entity.CreateSlime();
            var orc = Entity.CreateOrc();

            var mobs = new List<Entity> { slime, orc };

            // Initialize combat
            combat = new Combat(player, mobs);
        }

        public void Start()
        {
            combat.StartBattle();
        }
    }
}
