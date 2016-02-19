using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{
    public class MonsterBase
    {
        public string Name { get; set; }
        public int StartingHealth { get; set; }
        public int StartingDamage { get; set; }
        public string SkillOne { get; set; }
        public string SkillTwo { get; set; }
        public int SkillOneDamage { get; set; }
        public int SkillTwoDamage {get;set;}

        public void setStartingHealth()
        {

        }
    }

    
}
