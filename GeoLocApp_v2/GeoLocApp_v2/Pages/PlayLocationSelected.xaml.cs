using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public partial class PlayLocationSelected : ContentPage
    {
        string lOID;
        public PlayLocationSelected(string locID)
        {
            InitializeComponent();
            this.lOID = locID;
            LoadLocationDetails(lOID);
        }

        private async void LoadLocationDetails(string lID)
        {
            var x = await App.Database.GetPlayLocDetailsAsync(lID);
            locNameT.Text = x.playLocationName;
            locHintT.Text = x.playLocationHint;

        }
    }
}
