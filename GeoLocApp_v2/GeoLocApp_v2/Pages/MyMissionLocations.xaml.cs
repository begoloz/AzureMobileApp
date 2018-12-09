using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public partial class MyMissionLocations : ContentPage
    {
        int missionID;
        int locationID;
        public MyMissionLocations(int m_ID)
        {
            InitializeComponent();
            this.missionID = m_ID;

            Debug.WriteLine("lon construct MisID: " + missionID.ToString());
            Debug.WriteLine("lon construct LocID " + locationID.ToString());
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine("lon apear MisID: " + missionID.ToString());
            Debug.WriteLine("lon apear LocID " + locationID.ToString());

            LoadMissionLocationsAsync(missionID);
        }

        private async void LoadMissionLocationsAsync(int m_ID)
        {
            Debug.WriteLine("lLoad List MisID: " + missionID.ToString());
            Debug.WriteLine("lLoad List LocID " + locationID.ToString());

            var result = await App.Database.GetMyMissionLocationsAsync(m_ID);
            m_LocListView.ItemsSource = result;
        }

        void LocSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Models.MyMissionsLocations selectedLocation = (Models.MyMissionsLocations)m_LocListView.SelectedItem;
            locationID = selectedLocation.locationId;
            missionID = selectedLocation.missionId;

            Debug.WriteLine("lselect MissionID: " + missionID.ToString());
            Debug.WriteLine("lselect LocID(!=0): " + locationID.ToString());


            Navigation.PushAsync(new Pages.LocationInput(missionID,locationID));
        }

        void AddLocation(object sender, System.EventArgs e)
        {
            Debug.WriteLine("lAdd missionID: " + missionID.ToString());
            Debug.WriteLine("lAddLocID(0): " + locationID.ToString());
            Navigation.PushAsync(new Pages.LocationInput(missionID,locationID));
        }
    }
}
