using System;

using Xamarin.Forms;

namespace GeoLocApp_v2.Pages
{
    public class CameraCS : ContentPage
    {
        public CameraCS()
        {
            Title = "CameraCS";
            Padding = new Thickness(0, 20, 0, 0);
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Camera Preview (CS):" },
                    new Helpers.CameraPreview {
                        Camera = Helpers.CameraOptions.Rear,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }
                }
            };
        }
    }
}

