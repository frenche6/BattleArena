﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary.Monsters
{
    public class Goblin : MonsterBase
    {
        public Goblin()
        {
            Name = "goblin";
            StartingHealth = 10;
            StartingDamage = 20;
            SkillOne = "Hack";
            SkillTwo = "Headbutt";
            SkillOneDamage = 5;
            SkillTwoDamage = 10;
        }
    }
}
