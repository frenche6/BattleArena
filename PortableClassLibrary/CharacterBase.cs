using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{
    public class CharacterBase
    {
        public string className { get; set; }
        public int startingHealth { get; set; }
        public int startingDamage { get; set; }
        public int startingAbilityPoints { get; set; }
        public string classDescription { get; set; }
        public string skillOne { get; set; }
        public string skillTwo { get; set; }
        public string skillThree { get; set; }
        public string skillFour { get; set; }
        public int skillOneCost { get; set; }
        public int skillTwoCost { get; set; }
        public int skillThreeCost { get; set; }
        public int skillFourCost { get; set; }
        public int skillOneDamage { get; set; }
        public int skillTwoDamage { get; set; }
        public int skillThreeDamage { get; set; }
        public int skillFourDamage { get; set; }
    }
}
