﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BattleArena_PortableClassLibrary
{
    public class StorageManager
    {
        Windows.Storage.ApplicationDataContainer mRoamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
        private List<string> mScoreListNames = new List<string>();
        private List<int> mScoreListFinalScore = new List<int>();

        public void saveAppData()
        {
            //Character Model Data
            mRoamingSettings.Values["playerName"] = AppState.CharacterModel.PlayerName;
            mRoamingSettings.Values["playerClass"] = AppState.CharacterModel.CharacterClass;
            mRoamingSettings.Values["playerHealth"] = AppState.CharacterModel.PlayerHealth;
            mRoamingSettings.Values["playerDamage"] = AppState.CharacterModel.PlayerDamage;
            mRoamingSettings.Values["abilityPoints"] = AppState.CharacterModel.AbilityPoints;
            mRoamingSettings.Values["playerWins"] = AppState.CharacterModel.PlayerWins;
            mRoamingSettings.Values["playerSkillOne"] = AppState.CharacterModel.PlayerSkillOne;
            mRoamingSettings.Values["playerSkillTwo"] = AppState.CharacterModel.PlayerSkillTwo;
            mRoamingSettings.Values["playerSkillThree"] = AppState.CharacterModel.PlayerSkillThree;
            mRoamingSettings.Values["playerSkillFour"] = AppState.CharacterModel.PlayerSkillFour;
            mRoamingSettings.Values["playerSkillOneCost"] = AppState.CharacterModel.PlayerSkillOneCost;
            mRoamingSettings.Values["playerSkillTwoCost"] = AppState.CharacterModel.PlayerSkillTwoCost;
            mRoamingSettings.Values["playerSkillThreeCost"] = AppState.CharacterModel.PlayerSkillThreeCost;
            mRoamingSettings.Values["playerSkillFourCost"] = AppState.CharacterModel.PlayerSkillFourCost;
            mRoamingSettings.Values["characterExists"] = AppState.CharacterModel.CharacterExists;
            mRoamingSettings.Values["playerScore"] = AppState.CharacterModel.PlayerScore;

            foreach (var item in AppState.CharacterModel.PlayerScoreList)
            {
                WriteFinalScore(item);
            }

            //SerializeScoreList(AppState.CharacterModel.PlayerScoreList);
            //mRoamingSettings.Values["playerScoreNames"] = mScoreListNames;
            //mRoamingSettings.Values["playerScoreFinalScores"] = mScoreListFinalScore;

            //Monster Model Data
            mRoamingSettings.Values["monsterName"] = AppState.MonsterModel.MonsterName;
            mRoamingSettings.Values["monsterHealth"] = AppState.MonsterModel.MonsterHealth;
            mRoamingSettings.Values["monsterDamage"] = AppState.MonsterModel.MonsterDamage;

            //saveCharacterExists();

        }
        int mCurrentSavePosition = 0;
        private void WriteFinalScore(ScoreItem aScoreItem)
        {
            Windows.Storage.ApplicationDataCompositeValue lComposite = new Windows.Storage.ApplicationDataCompositeValue();
            lComposite["ScorePlayerName"] = aScoreItem.PlayerName;
            lComposite["ScoreFinalScore"] = aScoreItem.FinalScore;
            mRoamingSettings.Values["finalScoreList" + mCurrentSavePosition.ToString()] = lComposite;
            mCurrentSavePosition++;
        }

        private void LoadFinalScores()
        {
            for (int i = 0; i < 10; ++i )
            {
                if (mRoamingSettings.Values.ContainsKey("finalScoreList" + i.ToString()))
                {
                    //AppState.CharacterModel.PlayerScoreList[i] = (ScoreItem)mRoamingSettings.Values["finalScoreList" + i.ToString()].ToString();
                }
            }
        }

        //private void SerializeScoreList(List<ScoreItem> aScoreItemList)
        //{

        //    foreach (var item in AppState.CharacterModel.PlayerScoreList)
        //    {
        //        mScoreListNames.Add(item.PlayerName);
        //        mScoreListFinalScore.Add(item.FinalScore);
        //    }
        //}

        //private void DeSerializeScoreList(int aNameSize, int aScoreSize)
        //{
        //    if (aNameSize == aScoreSize)
        //    {
        //        for (int index = 0; index < aNameSize; index++)
        //        {
        //            ScoreItem lScoreToLoad = new ScoreItem(mScoreListNames[index], mScoreListFinalScore[index]);
        //            AppState.CharacterModel.PlayerScoreList.Add(lScoreToLoad);
        //        }
        //    }
        //}

        public void saveCharacterExists()
        {
            mRoamingSettings.Values["characterExists"] = AppState.CharacterModel.CharacterExists;
        }

        public void loadCharacterExists()
        {
            if (mRoamingSettings.Values.ContainsKey("characterExists"))
            {
                AppState.CharacterModel.CharacterExists = (bool)mRoamingSettings.Values["characterExists"];
            }
        }

        public void loadAppData()
        {
            //Character Model Data
            if (mRoamingSettings.Values.ContainsKey("playerName"))
            {
                AppState.CharacterModel.PlayerName = mRoamingSettings.Values["playerName"].ToString();
            }
            if (mRoamingSettings.Values.ContainsKey("playerClass"))
            {
                AppState.CharacterModel.CharacterClass = mRoamingSettings.Values["playerClass"].ToString();
            }
            if (mRoamingSettings.Values.ContainsKey("playerHealth"))
            {
                AppState.CharacterModel.PlayerHealth = (int)mRoamingSettings.Values["playerHealth"];
            }
            if (mRoamingSettings.Values.ContainsKey("playerDamage"))
            {
                AppState.CharacterModel.PlayerDamage = (int)mRoamingSettings.Values["playerDamage"];
            }
            if (mRoamingSettings.Values.ContainsKey("abilityPoints"))
            {
                AppState.CharacterModel.AbilityPoints = (int)mRoamingSettings.Values["abilityPoints"];
            }
            if (mRoamingSettings.Values.ContainsKey("playerWins"))
            {
                AppState.CharacterModel.PlayerWins = (int)mRoamingSettings.Values["playerWins"];
            }
            if (mRoamingSettings.Values.ContainsKey("playerScore"))
            {
                AppState.CharacterModel.PlayerScore = (int)mRoamingSettings.Values["playerScore"];
            }

            //DeSerializeScoreList(mScoreListNames.Count, mScoreListFinalScore.Count);
            


                if (mRoamingSettings.Values.ContainsKey("CharacterExists"))
                {
                    AppState.CharacterModel.CharacterExists = (bool)mRoamingSettings.Values["CharacterExists"];
                }

            if (mRoamingSettings.Values.ContainsKey("playerSkillOne"))
            {
                AppState.CharacterModel.PlayerSkillOne = mRoamingSettings.Values["playerSkillOne"].ToString();
            }
            if (mRoamingSettings.Values.ContainsKey("playerSkillTwo"))
            {
                AppState.CharacterModel.PlayerSkillTwo = mRoamingSettings.Values["playerSkillTwo"].ToString();
            }
            if (mRoamingSettings.Values.ContainsKey("playerSkillThree"))
            {
                AppState.CharacterModel.PlayerSkillThree = mRoamingSettings.Values["playerSkillThree"].ToString();
            }
            if (mRoamingSettings.Values.ContainsKey("playerSkillFour"))
            {
                AppState.CharacterModel.PlayerSkillFour = mRoamingSettings.Values["playerSkillFour"].ToString();
            }
            if (mRoamingSettings.Values.ContainsKey("playerSkillOneCost"))
            {
                AppState.CharacterModel.PlayerSkillOneCost = (int)mRoamingSettings.Values["playerSkillOneCost"];
            }
            if (mRoamingSettings.Values.ContainsKey("playerSkillTwoCost"))
            {
                AppState.CharacterModel.PlayerSkillTwoCost = (int)mRoamingSettings.Values["playerSkillTwoCost"];
            }
            if (mRoamingSettings.Values.ContainsKey("playerSkillThreeCost"))
            {
                AppState.CharacterModel.PlayerSkillThreeCost = (int)mRoamingSettings.Values["playerSkillThreeCost"];
            }
            if (mRoamingSettings.Values.ContainsKey("playerSkillFourCost"))
            {
                AppState.CharacterModel.PlayerSkillFourCost = (int)mRoamingSettings.Values["playerSkillFourCost"];
            }


            //Monster Data 
            if (mRoamingSettings.Values.ContainsKey("monsterName"))
            {
                AppState.MonsterModel.MonsterName = mRoamingSettings.Values["monsterName"].ToString();
            }
            if (mRoamingSettings.Values.ContainsKey("monsterHealth"))
            {
                AppState.MonsterModel.MonsterHealth = (int)mRoamingSettings.Values["monsterHealth"];
            }
            if (mRoamingSettings.Values.ContainsKey("monsterDamage"))
            {
                AppState.MonsterModel.MonsterDamage = (int)mRoamingSettings.Values["monsterDamage"];
            }

            loadCharacterExists();
        }
    }
}
