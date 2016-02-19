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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RandomBattleArena
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AppState characterstate = new AppState();
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            StorageManager lStorageManager = new StorageManager();
            lStorageManager.loadCharacterExists();
            if (AppState.CharacterModel.PlayerScoreList.Count != 10)
            {
                AppState.CharacterModel.padScoresList();
            }
            
        }

        private async void uLoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (AppState.CharacterModel.CharacterExists)
            {
                StorageManager lStorage = new StorageManager();
                //AppState.CharacterModel.CharacterExists = true;
                lStorage.loadAppData();
                //AppState.MonsterModel.GenerateMonster(1);
                this.Frame.Navigate(typeof(BattlePage));
            }
            else
            {
                MessageDialog lDialogBox = new MessageDialog("No saved character exists");
                await lDialogBox.ShowAsync();
            }
        }

        private void uNewGameButton_Click(object sender, RoutedEventArgs e)
        {            
            //AppState.CharacterModel.GenerateCharacter(100, 10, 4);
            //AppState.MonsterModel.GenerateMonster();
            this.Frame.Navigate(typeof(CharacterCreationPage));
        }

        private void uScoreList_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ScoreListPage));
        }

    }
}
