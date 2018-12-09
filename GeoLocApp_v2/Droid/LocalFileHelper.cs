using System;
using System.IO;
using GeoLocApp_v2.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace GeoLocApp_v2.Droid
{
    public class LocalFileHelper : Interfaces.ILocalFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "Databases"); //databases inside personal and new file
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}

