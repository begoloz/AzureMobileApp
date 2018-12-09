using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    /// <summary>
    /// displays navigation menu for playing options 
    /// </summary>
    public partial class PlayMenu : ContentPage
    {
        public PlayMenu()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Load();
        }

        void Go2FindMission(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Pages.MissionSelect());
        }

        private async void Load()
        {
            var result = await App.Database.GetAllPlayMissionsAsync();
            PlayMissionsList.ItemsSource = result;
        }

        void playMission(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Models.playMissionsModel missionPlaySelected = (Models.playMissionsModel)PlayMissionsList.SelectedItem;
            string selectionMOID = missionPlaySelected.playOMissionId;
            Navigation.PushAsync(new Pages.PlaySelectedMission(selectionMOID));
        }
    }
}
