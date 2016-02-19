using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{
    public class Class_Barbarian : CharacterBase
    {
        public Class_Barbarian()
        {
            className = "Barbarian";
            startingHealth = 2;
            startingDamage = 12;
            startingAbilityPoints = 5;
            classDescription = "The ability to smash foes with a single hand.";
            skillOne = "Punch";
            skillTwo = "Daze";
            skillThree = "Dismember";
            skillFour = "SkullCrack";
            skillOneCost = 1;
            skillTwoCost = 3;
            skillThreeCost = 5;
            skillFourCost = 9;
            skillOneDamage = 5;
            skillTwoDamage = 10;
            skillThreeDamage = 20;
            skillFourDamage = 40;

        }

        //public string className { get; set; }
        //public int startingHealth { get; set; }
        //public int startingDamage { get; set; }
        //public int startingAbilityPoints { get; set; }
        //public string classDescription { get; set; }
        //public string skillOne { get; set; }
        //public string skillTwo { get; set; }
        //public string skillThree { get; set; }
        //public string skillFour { get; set; }
        //public int skillOneCost { get; set; }
        //public int skillTwoCost { get; set; }
        //public int skillThreeCost { get; set; }
        //public int skillFourCost { get; set; }
        //public int skillOneDamage { get; set; }
        //public int skillTwoDamage { get; set; }
        //public int skillThreeDamage { get; set; }
        //public int skillFourDamage { get; set; }
        
 
    }
}
