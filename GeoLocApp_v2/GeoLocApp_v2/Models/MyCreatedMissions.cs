using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensionsAsync;

using Xamarin.Forms;

namespace GeoLocApp_v2.Models
{
    public class MyCreatedMissions
    {
        [PrimaryKey, AutoIncrement]
        public int missionId { get; set; }

        public String missionName { get; set; }

        public String missionMaker { get; set; }

        public String missionDescription { get; set; }

        public Boolean missionStatus { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<MyMissionsLocations> Locations { get; set; }
    }
}

