using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoLocApp_v2.Helpers
{
    public class LocationUploader 
    {
        
        //int mLocalID;
        public LocationUploader()
        {
            //this.mLocalID = missionLocalID;
            //SetMissionLocations(missionLocalID);

        }


        public async Task<System.Collections.Generic.List<Models.MyMissionsLocations>> getListLoc (int m_ID){
            var result = await App.Database.GetMyMissionLocationsAsync(m_ID);
            Debug.WriteLine(result);
            return result;
        }
        public static void SetMissionLocations(List<Models.MyMissionsLocations> result, int m_ID, string mOID)
        {
            //Debug.WriteLine("something!");
            foreach(var locLocation in result){

                OnlineModels.LocationOnlineModel uploadLocation = new OnlineModels.LocationOnlineModel();
                uploadLocation.locationName = locLocation.locationName;
                uploadLocation.gps = locLocation.gpsLocation;
                uploadLocation.hint = locLocation.locationHint;
                uploadLocation.maker = "bego";
                uploadLocation.lLocalID = locLocation.locationId;
                uploadLocation.mLocalID = m_ID;
                uploadLocation.missionOID = mOID;

                App.Service.AddOrUpdateLocationsDataAsync(uploadLocation);

            }
        }

    }
}

