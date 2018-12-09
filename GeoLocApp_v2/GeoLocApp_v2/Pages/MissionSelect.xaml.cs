using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    /// <summary>
    /// displays entrire mission list for a user*
    /// </summary>
    public partial class MissionSelect : ContentPage
    {
        readonly Services.GeoLocService service = new Services.GeoLocService();

        public MissionSelect()          //nedds to add user parameter
        {
            InitializeComponent();

        }

        //when page opens it loads missions list
        protected override void OnAppearing()
        {
            LoadMissionList("Bego");
        }

        //calls the task to get the mission list from the service and waist for it to finish, displays on UI
        private async void LoadMissionList(string user)
        {
            var result = await service.GetAvailableMissionsAsync(user);
            missionList.ItemsSource = result;
        }

        //on click of a mission it goes to the mission's details page
        void Handle_MissionSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            MissionDataModel missionMakerItem = (MissionDataModel)missionList.SelectedItem;
            string id1 = missionMakerItem.Id.ToString();
            Navigation.PushAsync(new Pages.MissionDetails(id1));
        }
    }

}
