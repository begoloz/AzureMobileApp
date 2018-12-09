using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    /// <summary>
    /// form to create new missions
    /// </summary>
    public partial class NewMission : ContentPage
    {
        readonly Services.GeoLocService service = new Services.GeoLocService();

        public NewMission()
        {
            InitializeComponent();
        }

        Models.MyCreatedMissions newMission;
        //save in local DB
        void submitMission(object sender, System.EventArgs e)
        {
            newMission = new Models.MyCreatedMissions();
            string missionName = m_name.Text;
            string missionDescription = m_des.Text;

            newMission.missionName = missionName;
            newMission.missionMaker = user;
            newMission.missionDescription = missionDescription;

            App.Database.SaveMyNewMissionAsync(newMission);
        }


        //when save is clicked it calls the method to submit
        void SaveMission(object sender, System.EventArgs e)
        {
            SubmitNewMission();
        }

        MissionDataModel missionDataModelSubmitLine;
        string user = "Bego";

        //assambles a mission item with user input data and submits it to the server
        void SubmitNewMission (){
            missionDataModelSubmitLine = new MissionDataModel();

            string missionName = m_name.Text;
            string missionDescription = m_des.Text;

            missionDataModelSubmitLine.missionMaker = user;
            missionDataModelSubmitLine.missionName = missionName;
            missionDataModelSubmitLine.missionDescription = missionDescription;

            service.AddOrUpdateMissionsDataAsync(missionDataModelSubmitLine);
        }
    }
}
