using System;

using Xamarin.Forms;

namespace GeoLocApp_v2.OnlineModels
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model for locations table from  the server
    /// </summary>
    [JsonObject(Title = "locations")]
    public class LocationOnlineModel 
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Delete")]
        public bool Delete { get; set; }

        [JsonProperty("locationName")]
        public string locationName { get; set; }

        [JsonProperty("gps")]
        public int gps { get; set; }

        [JsonProperty("hint")]
        public string hint { get; set; }

        [JsonProperty("maker")]
        public string maker { get; set; }


        [JsonProperty("mLocalID")]
        public int mLocalID { get; set; }

        [JsonProperty("lLocalID")]
        public int lLocalID { get; set; }

        [JsonProperty("missionOID")]
        public string missionOID { get; set; }

    }
}

