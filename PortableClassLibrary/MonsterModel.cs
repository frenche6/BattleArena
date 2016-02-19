using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{

    public enum monsterDifficultyEnum
    {
        Easy = 7,
        Medium = 15,
        Hard = 22
    };

    public class MonsterModel : INotifyPropertyChanged
    {
        Random mRandomNumber = new Random();              

        #region Class Attributes
        private string mMonsterName = "Monster";
        public string MonsterName
        {
            get { return mMonsterName; }
            set
            {
                mMonsterName = value;
                RaisePropertyChanged("MonsterName");
            }
        }

        private int mMonsterHealth = 0;
        public int MonsterHealth
        {
            get { return mMonsterHealth; }
            set
            {
                mMonsterHealth = value;
                RaisePropertyChanged("MonsterHealth");
            }
        }

        private int mMonsterDamage = 0;
        public int MonsterDamage
        {
            get { return mMonsterDamage; }
            set
            {
                mMonsterDamage = value;
                RaisePropertyChanged("MonsterDamage");
            }
        }

        private int mDifficultyLevel = 2;
        public int DifficultyLevel
        {
            get { return mDifficultyLevel; }
            set
            {
                mDifficultyLevel = value;
                RaisePropertyChanged("DifficultyLevel");
            }
        }

        private int mScoreValue = 1;
        public int ScoreValue
        {
            get { return mScoreValue; }
            set { SetProperty(ref mScoreValue, value);}
        }

        private bool mIsBleeding = false;
        public bool isBleeding
        {
            get { return mIsBleeding; }
            set { SetProperty(ref mIsBleeding, value); }
        }
        #endregion

        #region Class Functions
        private int generateMonsterDifficultyLevel(Random aRandom, int aMonsterDifficulty)
        {
            return aRandom.Next(aMonsterDifficulty / 2, aMonsterDifficulty * 2);
        }
        private int generateMonsterAttributes(Random aRandom, int aMonsterDifficulty)
        {
            return aRandom.Next(aMonsterDifficulty * 2, aMonsterDifficulty * 5);
        }

        public void GenerateMonster(int aDifficultyLevel)
        {
            DifficultyLevel = generateMonsterDifficultyLevel(mRandomNumber, aDifficultyLevel);
            MonsterHealth = generateMonsterAttributes(mRandomNumber, mDifficultyLevel);
            MonsterDamage = generateMonsterAttributes(mRandomNumber, mDifficultyLevel);
            generateScoreValue();
        }

        public void resetMonseter()
        {
            DifficultyLevel = 2;
            MonsterHealth = 1;
            MonsterDamage = 1;
        }

        private void generateScoreValue()
        {
            ScoreValue = DifficultyLevel * (mMonsterHealth + mMonsterDamage);
        }

        private int GenerateRandomDamage(Random aRandom)
        {
            return aRandom.Next(MonsterDamage / 5, MonsterDamage);
        }
        public int DealDamage(int aDamageModifier)
        {
            return GenerateRandomDamage(mRandomNumber) + aDamageModifier;            
        }
        #endregion

        #region Event handlers
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        #endregion
    }
}
