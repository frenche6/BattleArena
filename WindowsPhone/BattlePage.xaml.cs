using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BattleArena_PortableClassLibrary;
using System.Threading.Tasks;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace RandomBattleArena
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BattlePage : Page
    {
        #region Page Initialize
        StorageManager mStorageManager;
        public BattlePage()
        {
            this.InitializeComponent();
            mStorageManager = new StorageManager();
            SetDataContexts();            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            determineAvailableMoves(AppState.CharacterModel.AbilityPoints);
        }

        
        private void SetDataContexts()
        {
            uPlayerNameTextBlock.DataContext = AppState.CharacterModel;
            uPlayerHealthBlock.DataContext = AppState.CharacterModel;
            uPlayerDamageBlock.DataContext = AppState.CharacterModel;
            uPlayerAbilityPointsText.DataContext = AppState.CharacterModel;

            uMonsterNameTextBlock.DataContext = AppState.MonsterModel;
            uMonsterHealthBlock.DataContext = AppState.MonsterModel;
            uMonsterDamageBlock.DataContext = AppState.MonsterModel;


            uPlayerSkillOneText.DataContext = AppState.CharacterModel;
            uPlayerSkillTwoText.DataContext = AppState.CharacterModel;
            uPlayerSkillThreeText.DataContext = AppState.CharacterModel;
            uPlayerSkillFourText.DataContext = AppState.CharacterModel;
        }
        #endregion

        #region Player attacks
        private void PlayerAttack(int aDamageModifier, TextBlock aTextBlock)
        {
            int lPlayerDamageDealt = AppState.CharacterModel.DealDamage(aDamageModifier);
            AppState.MonsterModel.MonsterHealth -= lPlayerDamageDealt;
            aTextBlock.Text = "Monster took " + lPlayerDamageDealt + " damage.";

            if (AppState.MonsterModel.isBleeding)
            {
                AppState.MonsterModel.MonsterHealth -= (int)(AppState.MonsterModel.MonsterHealth * .1);
            }

            AppState.CombatLogList.CombatLogList.Insert(0, new CombatLogDescription() { Description = "Monster took " + lPlayerDamageDealt + " damage." });

        }
        #endregion

        #region Monster attacks
        private void MonsterAttack(int aDamageModifier, TextBlock aTextBlock)
        {
            int lMonsterDamageDealt = AppState.MonsterModel.DealDamage(aDamageModifier);
            AppState.CharacterModel.PlayerHealth -= lMonsterDamageDealt;
            aTextBlock.Text = "Player took " + lMonsterDamageDealt + " damage.";
            AppState.CombatLogList.CombatLogList.Insert(0, new CombatLogDescription() { Description = "Player took " + lMonsterDamageDealt + " damage." });
        }
        #endregion

        #region End of turn functions
        private void EndTurn()
        {
            AppState.CharacterModel.reGainAbilityPoints();            
            EvaluateBattle();
            mStorageManager.saveAppData();
            determineAvailableMoves(AppState.CharacterModel.AbilityPoints);
        }

        private void EvaluateBattle()
        {
            if (AppState.CharacterModel.PlayerHealth <= 0)
            {
                StorageManager lStorageManager = new StorageManager();

                AppState.CombatLogList.CombatLogList.Clear();
                AppState.CharacterModel.CharacterExists = false;
                AppState.CharacterModel.SaveFinalScore();

                lStorageManager.saveCharacterExists();
                this.Frame.Navigate(typeof(DefeatScreen));
            }
            else if (AppState.MonsterModel.MonsterHealth <= 0)
            {
                AppState.CharacterModel.PlayerWins++;
                AppState.CharacterModel.PlayerScore += AppState.MonsterModel.ScoreValue;
                AppState.MonsterModel.GenerateMonster((int)monsterDifficultyEnum.Easy);
                mStorageManager.saveAppData();
                this.Frame.Navigate(typeof(VictoryScreen));
            }
        }

        private void determineAvailableMoves(int aAbilityPoints)
        {
            if (aAbilityPoints < AppState.CharacterModel.PlayerSkillOneCost)
            {
                uplayerSkillOneButton.IsEnabled = false;
            }
            else
            {
                uplayerSkillOneButton.IsEnabled = true;
                uplayerSkillOneButton.Foreground = new SolidColorBrush(Colors.Green);
            }


            if (aAbilityPoints < AppState.CharacterModel.PlayerSkillTwoCost)
            {
                uplayerSkillTwoButton.IsEnabled = false;
            }
            else
            {
                uplayerSkillTwoButton.IsEnabled = true;
                uplayerSkillTwoButton.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (aAbilityPoints < AppState.CharacterModel.PlayerSkillThreeCost)
            {
                uplayerSkillThreeButton.IsEnabled = false;
            }
            else
            {
                uplayerSkillThreeButton.IsEnabled = true;
                uplayerSkillThreeButton.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (aAbilityPoints < AppState.CharacterModel.PlayerSkillFourCost)
            {
                uplayerSkillFourButton.IsEnabled = false;
            }
            else
            {
                uplayerSkillFourButton.IsEnabled = true;
                uplayerSkillFourButton.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        

        private void uAppBarCombatLog_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CombatLogPage));
        }

        private void uAppBarSaveState_Click(object sender, RoutedEventArgs e)
        {
            StorageManager lStorage = new StorageManager();
            lStorage.saveAppData();
            this.Frame.Navigate(typeof(MainPage));
        }
        #endregion

        #region Player Skill Button Handlers
        private void uplayerSkillOneButton_Click(object sender, RoutedEventArgs e)
        {

            AppState.CharacterModel.AbilityPoints -= AppState.CharacterModel.PlayerSkillOneCost;

            PlayerAttack(AppState.CharacterModel.PlayerSkillOneDamage, uDamageLogTextBlockPlayer);

            //Monster Attacks
            if (AppState.MonsterModel.MonsterHealth > 0)
            {
                MonsterAttack(3, uDamageLogTextBlockMonster);
            }

            EndTurn();
        }

        private void uplayerSkillTwoButton_Click(object sender, RoutedEventArgs e)
        {
            AppState.CharacterModel.AbilityPoints -= AppState.CharacterModel.PlayerSkillTwoCost;

            PlayerAttack(AppState.CharacterModel.PlayerSkillTwoDamage, uDamageLogTextBlockPlayer);

            //Monster Attacks
            if (AppState.MonsterModel.MonsterHealth > 0)
            {
                MonsterAttack(3, uDamageLogTextBlockMonster);
            }

            EndTurn();
        }

        private void uplayerSkillThreeButton_Click(object sender, RoutedEventArgs e)
        {
            AppState.CharacterModel.AbilityPoints -= AppState.CharacterModel.PlayerSkillThreeCost;

            PlayerAttack(AppState.CharacterModel.PlayerSkillThreeDamage, uDamageLogTextBlockPlayer);

            //Monster Attacks
            if (AppState.MonsterModel.MonsterHealth > 0)
            {
                MonsterAttack(3, uDamageLogTextBlockMonster);
            }

            EndTurn();
        }

        private void uplayerSkillFourButton_Click(object sender, RoutedEventArgs e)
        {
            AppState.CharacterModel.AbilityPoints -= AppState.CharacterModel.PlayerSkillFourCost;

            PlayerAttack(AppState.CharacterModel.PlayerSkillFourDamage, uDamageLogTextBlockPlayer);

            //Monster Attacks
            if (AppState.MonsterModel.MonsterHealth > 0)
            {
                MonsterAttack(3, uDamageLogTextBlockMonster);
            }

            EndTurn();
        }
        #endregion


    }
}
