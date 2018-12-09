using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Admin
{
    public partial class LocationsTable : ContentPage
    {
        public LocationsTable()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            Load();
        }

        private async void Load()
        {
            var result = await App.Database.GetAllMyLocationsAsync();
            locTable.ItemsSource = result;
        }

    }
}
