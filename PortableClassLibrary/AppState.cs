using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{
    public class AppState
    {
        public static CharacterModel CharacterModel = new CharacterModel() { PlayerName = "Player" };
        public static MonsterModel MonsterModel = new MonsterModel() { MonsterName = "Goblin" };
        public static CombatLog CombatLogList = new CombatLog();
    }
}
