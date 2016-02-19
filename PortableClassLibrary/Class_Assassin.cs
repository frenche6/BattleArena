using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{
    public class Class_Assassin : CharacterBase
    {
        public Class_Assassin()
        {
            className = "Assassin";
            startingHealth = 100;
            startingDamage = 17;
            startingAbilityPoints = 7;
            classDescription = "Uses high damage to eliminate foes quickly";
            skillOne = "Mark for Death";
            skillTwo = "Evade";
            skillThree = "Stab";
            skillFour = "Assassinate";
            skillOneCost = 1;
            skillTwoCost = 3;
            skillThreeCost = 5;
            skillFourCost = 9;
            skillOneDamage = 5;
            skillTwoDamage = 10;
            skillThreeDamage = 20;
            skillFourDamage = 40;
        }
    }
}
