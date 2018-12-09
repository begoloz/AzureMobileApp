using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public partial class LocationInput : ContentPage
    {
        int missionID; 
        Random ran = new Random();
        int gpsLoc;
        int locationID;


        public LocationInput(int m_id, int l_id)
        {
            InitializeComponent();
            this.missionID = m_id;
            this.locationID = l_id;
            Debug.WriteLine("linside edit MissionID: " + missionID.ToString());
            Debug.WriteLine("linsde edit LocationID atm(0 or not): " + locationID.ToString());
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine("ledit onapear MissionID: " + missionID.ToString());
            Debug.WriteLine("ledit on apear LocationID atm(0 or not): " + locationID.ToString());

            if (locationID!=0){
                LoadSelectedLocationAsync(locationID); 
            }

        }

        private async void LoadSelectedLocationAsync (int l_id)
        {
            Debug.WriteLine("lLoad2 Mission ID: " + missionID.ToString());
            Debug.WriteLine("lLoad2 LocationID " + locationID.ToString());

            var selectedLocation = await App.Database.GetMyLocationAsync(l_id);

            Debug.WriteLine("lGet loc by LocID: " + locationID.ToString());
            Debug.WriteLine("selected location-> " + selectedLocation.ToString());

            l_Name.Text = selectedLocation.locationName;
            l_Hint.Text = selectedLocation.locationHint;
            l_gps.Text = selectedLocation.gpsLocation.ToString();

        }

        void GetLocation(object sender, System.EventArgs e)
        {
            gpsLoc = ran.Next();
            l_gps.Text = gpsLoc.ToString();
        }

        Models.MyMissionsLocations newLocation;
        void SaveLocation(object sender, System.EventArgs e)
        {
            newLocation = new Models.MyMissionsLocations();

            string locationName = l_Name.Text;
            string locationHint = l_Hint.Text;
            gpsLoc = Int32.Parse(l_gps.Text);

            if (locationID != 0) { 
                newLocation.locationId = locationID; 
            }
            newLocation.gpsLocation = gpsLoc;
            newLocation.locationName = locationName;
            newLocation.locationHint = locationHint;
            newLocation.missionId = missionID;

            App.Database.SaveMyNewLocationAsync(newLocation);

            Debug.WriteLine("lsaved Mission ID: " + missionID.ToString());
            Debug.WriteLine("lsaved LocationID atm(0or not): " + locationID.ToString());

            Navigation.PopAsync();
        }

        void DeletLocation(object sender, System.EventArgs e)
        {
            App.Database.DeleteMyLocationAsync(App.Database.GetMyLocationAsync(locationID).Result);
            Navigation.PopAsync();
        }


        //photo code
        void GoToAddPhoto(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new Pages.Camera());
            Navigation.PushAsync(new Pages.TakePhoto());
        }
        //photo code
    }


}
