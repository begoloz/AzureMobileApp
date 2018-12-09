using System;
using SQLite;
//using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;
using SQLiteNetExtensionsAsync;
using SQLiteNetExtensions.Attributes;

namespace GeoLocApp_v2.Models
{
    public class playLocationsModel
    {
        
        public string playOLocationId { get; set; }

        public string playOMissionId { get; set; }

        public int playGpsLocation { get; set; }

        public string playLocationName { get; set; }

        public string playLocationHint { get; set; }

        public Boolean playLocationStatus { get; set; }

    }
}

