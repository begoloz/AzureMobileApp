using System;
using Xamarin.Forms;


namespace GeoLocApp_v2
{
    using Newtonsoft.Json;
    /// <summary>
    /// Model for missions table from  the server
    /// </summary>
    [JsonObject(Title ="missions")]
    public class MissionDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Delete")]
        public bool Delete { get; set; }

        [JsonProperty("missionName")]
        public string missionName { get; set; }

        [JsonProperty("missionMaker")]
        public string missionMaker { get; set; }

        [JsonProperty("hintL1")]
        public string hintL1 { get; set; }

        [JsonProperty("missionDescription")]
        public string missionDescription { get; set; }


        [JsonProperty("localID")]
        public int localID { get; set; }

    }
}

