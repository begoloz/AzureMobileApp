using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public partial class Login : ContentPage
    {
        //auth
        bool authenticated = false;
        //auth

        public Login()
        {
            InitializeComponent();
        }

        async void Handle_Signin(object sender, System.EventArgs e)
        {
            //Models.UserModel user = new Models.UserModel(Entry_username.Text,Entry_password.Text);
            //if(user.CheckInfo()){
            //    DisplayAlert("Login", "Login succes!", "ok");
            //}else{
            //    DisplayAlert("Login", "Login not succesful, empty username or password", "ok");
            //}

            if (App.Authenticator != null)
                await DisplayAlert("Login-auth", "NULL", "ok");
                authenticated = await App.Authenticator.Authenticate();

            // Set syncItems to true to synchronize the data on startup when offline is enabled.
            if (authenticated == true)
                await DisplayAlert("Login-auth", "Login succes!", "ok");
                //await RefreshItems(true, syncItems: false);
        }
    }
}
