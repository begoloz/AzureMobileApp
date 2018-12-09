using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public partial class MyMissionEditor : ContentPage
    {
        int missionID;
        String mOID;
        public MyMissionEditor(int id)
        {
            InitializeComponent();
            this.missionID = id;
            Debug.WriteLine("what misison? + : " + missionID.ToString());
        }

        protected override void OnAppearing()
        {
            if (missionID != 0) {
                LoadMyMissionSelectedAsync(missionID);
            }
        }

        private async void LoadMyMissionSelectedAsync (int id)
        {
            var x = await App.Database.GetMyMissionAsync(id);
            m_Des.Text = x.missionDescription;
            m_Name.Text = x.missionName;
            //m_Status.Text = x.missionStatus.ToString();
        }

        Models.MyCreatedMissions newMission;
        void SaveMissionLocal(object sender, System.EventArgs e)
        {
            newMission = new Models.MyCreatedMissions();

            if (missionID !=0){
                newMission.missionId = missionID;
            } 

            string missionName = m_Name.Text;
            string missionDescription = m_Des.Text;

            newMission.missionName = missionName;
            newMission.missionDescription = missionDescription;
            newMission.missionMaker = "bego";


            App.Database.SaveMyNewMissionAsync(newMission);
            String buttonID = (sender as Button).StyleId;


            //save as on screen if mission not new first if keeps ID
            if (buttonID.Equals("SaveButton")){ 
                Debug.WriteLine("Save + : " + missionID.ToString());
                Navigation.PopAsync();
                //comes from loadMissions 
            }
            if (buttonID.Equals("UploadButton")){
                newMission.missionStatus = true;
                App.Database.SaveMyNewMissionAsync(newMission);
            }
            else {
                if (missionID == 0){ //new mission get saved and new ID recovered and set
                    missionID = App.Database.GetLastIdMissionAsync().Result;
                }
                // loadMission of existing mission mission ID already set
                //Navigation.PushAsync(new Pages.MyMissionLocations(missionID));                   
            }  
        }

        void DeleteMission(object sender, System.EventArgs e)
        {
            App.Database.DeleteMyMissionAsync(App.Database.GetMyMissionAsync(missionID).Result);
            App.Database.DeleteLocInMissionAsync(missionID);//->COULD BE IMPLEMENTED BETTER WITH SQLITE EXTENSIONS !
            Navigation.PopAsync(); 
        }

        void ViewLocations(object sender, System.EventArgs e)
        {
            SaveMissionLocal(sender, e);
            Debug.WriteLine("Locations + : " + missionID.ToString());
            Navigation.PushAsync(new Pages.MyMissionLocations(missionID));
        }

        void UploadMission(object sender, System.EventArgs e)
        {
            int numLoc = App.Database.CountLocInMissionAsync(missionID).Result;
            if (numLoc >= 3){
                //upload
                SaveMissionLocal(sender, e);
                Models.MyCreatedMissions missionUpload = App.Database.GetMyMissionAsync(missionID).Result;
                Helpers.MissionUploader.UploadMission(missionUpload);


                //var locations2Upload = App.Database.GetMyMissionLocationsAsync(missionID).Result;//get all locations from that mission to upload next
                Debug.WriteLine("shoulve uploaded mission name at least!");

                Debug.WriteLine("LOCAL MID TO FIND:"+missionID);
                GetOID(missionID);//get online id from local id and maker*!! aaaand upload locations

                DisplayAlert(m_Name.Text, "has been uploaded", "OK");
            } else {
                int leftOver = 3 - numLoc;
                DisplayAlert(m_Name.Text+" Cant be uploaded", "you need at least "+ leftOver +" more locations on your mission" , "OK");
            }

        }

        private async void GetOID(int m_ID)
        {
            var x = await App.Service.GetOnlineIDAsync(m_ID);
            while (!x.Any()){
                x = await App.Service.GetOnlineIDAsync(m_ID);
            }
            mOID = x.First().Id;
            Debug.WriteLine("IDstring:"+ x.ToString());
            Debug.WriteLine("ID:" + mOID);
            var locations2Upload = App.Database.GetMyMissionLocationsAsync(missionID).Result;
            Helpers.LocationUploader.SetMissionLocations(locations2Upload, missionID, mOID);
          
        }
    }
}
