using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public partial class PlaySelectedMission : ContentPage
    {
        string missionOID;
        public PlaySelectedMission(string mOID)
        {
            InitializeComponent();
            this.missionOID = mOID;
        }

        protected override void OnAppearing()
        {
            Load();
        }

        //click on location from list PLAY
        void locationSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Models.playLocationsModel playLocationSelected = (Models.playLocationsModel)Loc4PlayMissionList.SelectedItem;
            string locOID = playLocationSelected.playOLocationId;
            Navigation.PushAsync(new Pages.PlayLocationSelected(locOID));
        
        }

        private async void Load()
        {
            var result = await App.Database.GetAllPlayLoc4MAsync(missionOID);//GetAllPlayMissionsAsync();
            Loc4PlayMissionList.ItemsSource = result;
        }


    }
}
