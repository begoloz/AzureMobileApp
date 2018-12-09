using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    /// <summary>
    /// displays main menu for startup options *after log in
    /// </summary>
    public partial class StartMenu : ContentPage
    {
        
        void Handle_Clicked_PlayMenu(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Pages.PlayMenu());
        }

        void Handle_Clicked_MyMissions(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Pages.MyMissions());
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Pages.NewMission());
        }

        void GoTableLoc(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Admin.LocationsTable());
        }



        //bool authenticated = false;
       void Handle_Clicked_LogIn(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Pages.Login());
        }



        public StartMenu()
        {
            InitializeComponent();
        }


    }
}
