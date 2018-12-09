using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace GeoLocApp_v2.Interfaces
{
    public interface IPlatformLogin
    {
        Task PlatformLoginAsync(MobileServiceAuthenticationProvider provider, MobileServiceClient client);
    }
}

