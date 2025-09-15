using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny_Project.Player_Data
{
    public partial class player_data(string name, float damage, float Health, float speed, int level)
    {

        public void Leveling_system(int current_xp, int max_xp)
        {
            

            if (current_xp == max_xp)
            {
                level++;
                current_xp = 0;
                max_xp += 100;
                damage += 5;
                Health += 20;
                speed += 0.5f;
                max_xp = 100 + max_xp * (level / 2);

            } 
            else if (current_xp > max_xp) //xp overflow
            {
                
            }

        }
    }
}
