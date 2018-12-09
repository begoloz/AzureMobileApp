using System;
using SQLite;
//using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;
using SQLiteNetExtensionsAsync;
using SQLiteNetExtensions.Attributes;

namespace GeoLocApp_v2.Models
{
    public class MyMissionsLocations 
    {
        [PrimaryKey, AutoIncrement]
        public int locationId { get; set; }

        [ForeignKey(typeof(MyCreatedMissions))]
        public int missionId { get; set; }

        public int gpsLocation { get; set; }

        public string locationName { get; set; }

        public string locationHint { get; set; }

    }
}

