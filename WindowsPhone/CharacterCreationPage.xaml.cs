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
using Windows.UI.Popups;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace RandomBattleArena
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CharacterCreationPage : Page
    {
        Class_Barbarian mBarbarian = new Class_Barbarian();
        Class_Assassin mAssassin = new Class_Assassin();

        string mClassSelected = string.Empty;

        public CharacterCreationPage()
        {
            this.InitializeComponent();
            setBindings();
        }

        private void setBindings()
        {
            uRadioButton1.DataContext = mBarbarian;
            uRadioButton2.DataContext = mAssassin;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            uRadioButton1_Click(null, null);
            uRadioButton1.IsChecked = true;
            mClassSelected = mBarbarian.className;
            uChangeNameTextBox.Text = "Player";

        }

        private async void AppBarForward_Click(object sender, RoutedEventArgs e)
        {
            if (checkIfSurveyComplete())
            {
                AppState.CharacterModel.CharacterExists = true;
                AppState.MonsterModel.GenerateMonster(AppState.MonsterModel.DifficultyLevel);
                this.Frame.Navigate(typeof(BattlePage));
            }
            else
            {
                MessageDialog lDialogBox = new MessageDialog("Must select class and input name");
                await lDialogBox.ShowAsync();
            }
        }

        private void setCharacterDataStats(CharacterBase aBaseClass)
        {
            AppState.CharacterModel.CharacterClass = aBaseClass.className;
            AppState.CharacterModel.PlayerHealth = aBaseClass.startingHealth;
            AppState.CharacterModel.PlayerDamage = aBaseClass.startingDamage;
            AppState.CharacterModel.AbilityPoints = aBaseClass.startingAbilityPoints;
            AppState.CharacterModel.PlayerSkillOne = aBaseClass.skillOne;
            AppState.CharacterModel.PlayerSkillTwo = aBaseClass.skillTwo;
            AppState.CharacterModel.PlayerSkillThree = aBaseClass.skillThree;
            AppState.CharacterModel.PlayerSkillFour = aBaseClass.skillFour;
            AppState.CharacterModel.PlayerSkillOneCost = aBaseClass.skillOneCost;
            AppState.CharacterModel.PlayerSkillTwoCost = aBaseClass.skillTwoCost;
            AppState.CharacterModel.PlayerSkillThreeCost = aBaseClass.skillThreeCost;
            AppState.CharacterModel.PlayerSkillFourCost = aBaseClass.skillFourCost;
            AppState.CharacterModel.PlayerSkillOneDamage = aBaseClass.skillOneDamage;
            AppState.CharacterModel.PlayerSkillTwoDamage = aBaseClass.skillTwoDamage;
            AppState.CharacterModel.PlayerSkillThreeDamage = aBaseClass.skillThreeDamage;
            AppState.CharacterModel.PlayerSkillFourDamage = aBaseClass.skillFourDamage;
            AppState.CharacterModel.PlayerWins = 0;
            AppState.CharacterModel.PlayerScore = 0;
        }


        private void uRadioButton1_Click(object sender, RoutedEventArgs e)
        {
            uSkillOneTextBlock.DataContext = mBarbarian;
            uSkillTwoTextBlock.DataContext = mBarbarian;
            uSkillThreeTextBlock.DataContext = mBarbarian;
            uSkillFourTextBlock.DataContext = mBarbarian;

            uStartingHealthTextBlock.DataContext = mBarbarian;
            uStartingDamageTextBlock.DataContext = mBarbarian;
            uStartingAbilityPowerTextBlock.DataContext = mBarbarian;

            setCharacterDataStats(mBarbarian);

        }

        private void uRadioButton2_Click(object sender, RoutedEventArgs e)
        {
            mClassSelected = mAssassin.className;

            uSkillOneTextBlock.DataContext = mAssassin;
            uSkillTwoTextBlock.DataContext = mAssassin;
            uSkillThreeTextBlock.DataContext = mAssassin;
            uSkillFourTextBlock.DataContext = mAssassin;

            uStartingHealthTextBlock.DataContext = mAssassin;
            uStartingDamageTextBlock.DataContext = mAssassin;
            uStartingAbilityPowerTextBlock.DataContext = mAssassin;

            setCharacterDataStats(mAssassin);
        }

        private void uChangeNameTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (uChangeNameTextBox.Text == string.Empty)
                {
                    AppState.CharacterModel.PlayerName = "Player";
                }
                else
                {
                    AppState.CharacterModel.PlayerName = uChangeNameTextBox.Text;
                }
                //A hack to drop keyboard from screen
                uChangeNameTextBox.IsEnabled = false;
                uChangeNameTextBox.IsEnabled = true;
            }
        }

        private bool checkIfSurveyComplete()
        {
            bool lSurveyComplete = false;

            if (mClassSelected != string.Empty && uChangeNameTextBox.Text != string.Empty)
            {
                lSurveyComplete = true;
            }

            return lSurveyComplete;
        }

        private void uChangeNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            uChangeNameTextBox.Text = string.Empty;
        }

        private void uChangeNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (uChangeNameTextBox.Text != string.Empty)
            {
                AppState.CharacterModel.PlayerName = uChangeNameTextBox.Text;
            }
            else
            {
                uChangeNameTextBox.Text = "Player";
                AppState.CharacterModel.PlayerName = uChangeNameTextBox.Text;
            }
        }

        private void uAppBarQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }


    }
}
