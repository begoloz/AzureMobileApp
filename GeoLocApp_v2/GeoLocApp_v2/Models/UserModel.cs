using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GeoLocApp_v2.Models
{
    /// <summary>
    /// Model for users table from  the server
    /// </summary>
    [JsonObject(Title = "users")]
    public class UserModel : ContentPage
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public UserModel(){}
        public UserModel(string Username, string Password) {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInfo(){
            if (!(this.Username.Equals("")) && !(this.Password.Equals(""))){
                return true;
            }else {
                return false;
                }
        }


    }
}


