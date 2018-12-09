using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

using GeoLocApp_v2.Pages; //photo

using Foundation;
using UIKit;
using static GeoLocApp_v2.App;
using Microsoft.Identity.Client;

namespace GeoLocApp_v2.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate ,IAuthenticate
    {


        //auth 2
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
            return true;
        }
        //auth2

        //auth 1
        //public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate , IAuthenticate
        //auth 1

        // Define a authenticated user. 1
 private MobileServiceUser user;

        public async Task<bool> Authenticate()
        {
            var success = false;
            var message = string.Empty;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                if (user == null)
                {
                    user = await App.Service.CurrentClient.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,
                                 MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, "https://geolocapp.azurewebsites.net/.auth/login/aad/callback"); //auth2
                                 // MobileServiceAuthenticationProvider.Facebook, "geolocapp://easyauth.callback"); //auth1
                    if (user != null)
                    {
                        message = string.Format("You are now signed-in as {0}.", user.UserId);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            UIAlertView avAlert = new UIAlertView("Sign-in result", message, null, "OK", null);
            avAlert.Show();

            return success;
        }
        //auth 1

        ////auth 1
        //public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        //{
        //    return App.Service.CurrentClient.ResumeWithURL(url);
        //}
        ////auth 1



        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Link to Server
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif
            //auth 1
            App.Init(this);
            //auth 1

            LoadApplication(new App());

    
            return base.FinishedLaunching(app, options);
        }
    }
}
