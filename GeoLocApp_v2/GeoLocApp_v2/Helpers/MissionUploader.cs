using System;

using Xamarin.Forms;

namespace GeoLocApp_v2.Helpers
{
    public class MissionUploader  
    {
        //static MissionDataModel uploadMission;
        static Models.MyCreatedMissions localMission;

        public MissionUploader(Models.MyCreatedMissions mission)
        {
            //uploadMission = new MissionDataModel();
            localMission = mission;

        }
        public  static void UploadMission (Models.MyCreatedMissions localMission){
            MissionDataModel uploadMission = new MissionDataModel();
            uploadMission.missionName = localMission.missionName;
            uploadMission.missionMaker = localMission.missionMaker;
            uploadMission.missionDescription = localMission.missionDescription;
            uploadMission.localID = localMission.missionId;


            App.Service.AddOrUpdateMissionsDataAsync(uploadMission);
        }
    }
}

