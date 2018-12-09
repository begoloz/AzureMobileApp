using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensionsAsync;

namespace GeoLocApp_v2.Models
{
    public class playMissionsModel 
    {
        public string playOMissionId { get; set; }

        public String playMissionName { get; set; }

        public String playMissionMaker { get; set; }

        public String playMissionDescription { get; set; }

        public Boolean playMissionStatus { get; set; }

    }
}

