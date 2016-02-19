using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{
    public class CharacterModel : INotifyPropertyChanged
    {
        Random mRandomNumber = new Random();

        #region Player attributes
        private bool mCharacterExists = false;
        public bool CharacterExists
        {
            get { return mCharacterExists; }
            set
            {
                mCharacterExists = value;
                RaisePropertyChanged("CharacterExists");
            }
        }

        private string mPlayerName = "Player";
        public string PlayerName
        {
            get { return mPlayerName; }
            set
            {
                mPlayerName = value;
                RaisePropertyChanged("PlayerName");
            }
        }

        private string mCharacterClass = "None";
        public string CharacterClass
        {
            get { return mCharacterClass; }
            set
            {
                mCharacterClass = value;
                RaisePropertyChanged("CharacterClass");
            }
        }

        private int mPlayerHealth = 0;
        public int PlayerHealth
        {
            get { return mPlayerHealth; }
            set
            {
                mPlayerHealth = value;
                RaisePropertyChanged("PlayerHealth");
            }
        }

        private int mPlayerDamage = 0;
        public int PlayerDamage
        {
            get { return mPlayerDamage; }
            set
            {
                mPlayerDamage = value;
                RaisePropertyChanged("PlayerDamage");
            }
        }

        private int mAbilityPoints = 0;
        public int AbilityPoints
        {
            get { return mAbilityPoints; }
            set
            {
                mAbilityPoints = value;
                RaisePropertyChanged("AbilityPoints");
            }
        }

        public void reGainAbilityPoints()
        {            
            if (AbilityPoints <= 8)
            {
                AbilityPoints += 2;
            }
            else
            {
                AbilityPoints = 10;
            }
        }

        private int mPlayerWins = 0;
        public int PlayerWins
        {
            get { return mPlayerWins; }
            set
            {
                mPlayerWins = value;
                RaisePropertyChanged("PlayerWins");
            }
        }

        private int mPlayerScore = 0;
        public int PlayerScore
        {
            get { return mPlayerScore; }
            set
            {
                SetProperty(ref mPlayerScore, value);
            }
        }

        private List<ScoreItem> mPlayerScoreList = new List<ScoreItem>();
        public List<ScoreItem> PlayerScoreList
        {
            get { return mPlayerScoreList; }
            set { SetProperty(ref mPlayerScoreList, value); }
        }

        private string mPlayerSkillOne = "SkillOne";
        public string PlayerSkillOne
        {
            get { return mPlayerSkillOne; }
            set
            {
                mPlayerSkillOne = value;
                RaisePropertyChanged("PlayerSkillOne");
            }
        }

        private string mPlayerSkillTwo = "SkillTwo";
        public string PlayerSkillTwo
        {
            get { return mPlayerSkillTwo; }
            set
            {
                mPlayerSkillTwo = value;
                RaisePropertyChanged("PlayerSkillTwo");
            }
        }

        private string mPlayerSkillThree = "SkillThree";
        public string PlayerSkillThree
        {
            get { return mPlayerSkillThree; }
            set
            {
                mPlayerSkillThree = value;
                RaisePropertyChanged("PlayerSkillThree");
            }
        }
        private string mPlayerSkillFour = "SkillFour";
        public string PlayerSkillFour
        {
            get { return mPlayerSkillFour; }
            set
            {
                //mPlayerSkillFour = value;
                //RaisePropertyChanged("PlayerSkillFour");
                SetProperty(ref mPlayerSkillFour, value);
            }
        }

        private int mPlayerSkillOneCost = 0;
        public int PlayerSkillOneCost
        {
            get { return mPlayerSkillOneCost; }
            set
            {
                mPlayerSkillOneCost = value;
                RaisePropertyChanged("PlayerSkillOneCost");
            }
        }
        private int mPlayerSkillTwoCost = 0;
        public int PlayerSkillTwoCost
        {
            get { return mPlayerSkillTwoCost; }
            set
            {
                mPlayerSkillTwoCost = value;
                RaisePropertyChanged("PlayerSkillTwoCost");
            }
        }
        private int mPlayerSkillThreeCost = 0;
        public int PlayerSkillThreeCost
        {
            get { return mPlayerSkillThreeCost; }
            set
            {
                mPlayerSkillThreeCost = value;
                RaisePropertyChanged("PlayerSkillThreeCost");
            }
        }

        private int mPlayerSkillFourCost = 0;
        public int PlayerSkillFourCost
        {
            get { return mPlayerSkillFourCost; }
            set
            {
                //mPlayerSkillFourCost = value;
                //RaisePropertyChanged();
                SetProperty(ref mPlayerSkillFourCost, value);
            }
        }

        private int mPlayerSkillOneDamage = 0;
        public int PlayerSkillOneDamage
        {
            get { return mPlayerSkillOneDamage; }
            set
            {
                //mPlayerSkillOneDamage = value;
                //RaisePropertyChanged();
                SetProperty(ref mPlayerSkillOneDamage, value);
            }
        }

        private int mPlayerSkillTwoDamage = 0;
        public int PlayerSkillTwoDamage
        {
            get { return mPlayerSkillTwoDamage; }
            set
            {
                SetProperty(ref mPlayerSkillTwoDamage, value);
            }
        }

        private int mPlayerSkillThreeDamage = 0;
        public int PlayerSkillThreeDamage
        {
            get { return mPlayerSkillThreeDamage; }
            set
            {
                SetProperty(ref mPlayerSkillThreeDamage, value);
            }
        }

        private int mPlayerSkillFourDamage = 0;
        public int PlayerSkillFourDamage
        {
            get { return mPlayerSkillFourDamage; }
            set
            {
                SetProperty(ref mPlayerSkillFourDamage, value);
            }
        }
        #endregion

        #region Player Functions
        public void GenerateCharacter(int aPlayerHealth, int aPlayerDamage, int aAbilityPoints)
        {
                PlayerHealth = aPlayerHealth;
                PlayerDamage = aPlayerDamage;
                AbilityPoints = aAbilityPoints;
                CharacterExists = true;
                PlayerWins = 0;
        }

        public void resetCharacter()
        {
            CharacterExists = false;
            PlayerHealth = 0;
            PlayerDamage = 0;
        }

        private int GenerateRandomDamage(Random aRandom)
        {
            return aRandom.Next(PlayerDamage / 5, PlayerDamage);
        }


        public int DealDamage(int aDamageModifier)
        {
            return GenerateRandomDamage(mRandomNumber) + aDamageModifier;
        }


        public void SaveFinalScore()
        {
            ScoreItem lItemToSave = new ScoreItem(mPlayerName, mPlayerScore);
            int lLowestRecordedScore = 0;
            
            if (mPlayerScoreList.Count != 0)
            {
                lLowestRecordedScore = mPlayerScoreList.Last().FinalScore;
            }
            mPlayerScoreList.Add(lItemToSave);
            
            if (lLowestRecordedScore < mPlayerScore && mPlayerScoreList.Count > 10)
            {
                //mPlayerScoreList.Sort();
                mPlayerScoreList.Remove(mPlayerScoreList.Last());                
            }
            else
            {
                //mPlayerScoreList.Sort();
            }
        }

        public void padScoresList()
        {
            ScoreItem lScore = new ScoreItem("Player", 0);
            while (PlayerScoreList.Count != 10)
            {
                PlayerScoreList.Insert(0, lScore);
            }
        }
        #endregion

        #region Event handlers
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var lPropertyChanged = this.PropertyChanged;
            if (lPropertyChanged != null)
            {
                lPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) 
                return false;

            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }
        //SetProperty(ref _srBoardRecid, value);
        #endregion


    }
}
