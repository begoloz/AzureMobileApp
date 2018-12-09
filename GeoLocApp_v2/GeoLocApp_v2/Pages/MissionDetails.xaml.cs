using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    /// <summary>
    /// displays the details of one mission by ID
    /// </summary>
    public partial class MissionDetails : ContentPage
    {
        readonly Services.GeoLocService service = new Services.GeoLocService();
        string missionID;

        public MissionDetails(string missionID)
        {
            InitializeComponent();
            this.missionID = missionID;
            LoadMissionDetails(missionID);


        }

        // calls the task to get mission details and waits till it completes, dipslays info on UI
        private async void LoadMissionDetails(string ID)
        {
            var x = await service.GetMissionDetailsAsync(ID);
            details.Text = x.missionDescription;
            name.Text = x.missionName;
            maker.Text = x.missionMaker;

        }

        void add2Play(object sender, System.EventArgs e)
        {
            Download2Play(missionID);
            Navigation.PopAsync();

        }

        //download mission to local DB
        private async void Download2Play(string ID)
        {
            Models.playMissionsModel playMission = new Models.playMissionsModel();
            var x = await service.GetMissionDetailsAsync(ID);
            while (x==null){
                x = await service.GetMissionDetailsAsync(ID);
            }
            playMission.playOMissionId = x.Id;
            playMission.playMissionDescription = x.missionDescription;
            playMission.playMissionName = x.missionName;
            playMission.playMissionMaker = x.missionMaker;
            playMission.playMissionStatus = false;

            await App.Database.SavePlayMission(playMission);

            var y = await service.GetOLocations4MissionAsync(ID);
            while (!y.Any())
            {
                y = await service.GetOLocations4MissionAsync(ID);
            }
            foreach(var Olocation in y){
                Models.playLocationsModel playLocation = new Models.playLocationsModel();
                playLocation.playOMissionId = Olocation.missionOID;
                playLocation.playOLocationId = Olocation.Id;
                playLocation.playLocationName = Olocation.locationName;
                playLocation.playGpsLocation = Olocation.gps;
                playLocation.playLocationHint = Olocation.hint;
                playLocation.playLocationStatus = false;

                await App.Database.SavePlayLocation(playLocation);

            } 

        }

    }
}
