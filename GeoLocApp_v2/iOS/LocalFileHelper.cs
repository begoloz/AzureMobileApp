using System;
using System.IO;
using GeoLocApp_v2.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace GeoLocApp_v2.iOS
{
    public class LocalFileHelper : Interfaces.ILocalFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases"); //i think is to enter library folder
            if (!Directory.Exists(libFolder)) {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}

