using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using static GeoLocApp_v2.App;
using Microsoft.Identity.Client;

namespace GeoLocApp_v2.Droid
{
    [Activity(Label = "GeoLocApp_v2.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity , IAuthenticate //auth Interface 1
    {

        // Define a authenticated user. 1
        private MobileServiceUser user;

        public async Task<bool> Authenticate()
        {
            var success = false;
            var message = string.Empty;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await App.Service.CurrentClient.LoginAsync(this,
                    MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, "https://geolocapp.azurewebsites.net/.auth/login/aad/callback"); //auth2                                             
                    //MobileServiceAuthenticationProvider.Facebook, "geolocapp://easyauth.callback"); //auth1
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.",
                        user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();

            return success;
        }
        //auth 1

        //protected override void OnCreate(Bundle bundle) 1 antes
        //{
        //    TabLayoutResource = Resource.Layout.Tabbar;
        //    ToolbarResource = Resource.Layout.Toolbar;

        //    base.OnCreate(bundle);

        //    //Link to Server
        //    Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

        //    global::Xamarin.Forms.Forms.Init(this, bundle);

        //    ////auth 1
        //    //// Initialize the authenticator before loading the app.
        //    //App.Init((IAuthenticate)this);
        //    ////auth 1

        //    LoadApplication(new App()); 
        //} 1 antes


        // auth2
        protected override void OnCreate(Bundle bundle)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            LoadApplication(new App());
            //App.UiParent = new UIParent(this);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }
        //auth2
    }
}
