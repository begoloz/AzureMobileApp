using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public partial class MyMissions : ContentPage
    {
        public MyMissions()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            LoadMyMissionsListAsync();
        }

        private async void LoadMyMissionsListAsync()
        {
            var result = await App.Database.GetAllMyMissionsAsync();
            myMissionsListView.ItemsSource = result;
        }

        void MyMissionSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Models.MyCreatedMissions myMissionSelected = (Models.MyCreatedMissions)myMissionsListView.SelectedItem;
            int id = myMissionSelected.missionId;
            Navigation.PushAsync(new Pages.MyMissionEditor(id));
        }
       
        void EditNewMission(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Pages.MyMissionEditor(0));
        }
    }
}
