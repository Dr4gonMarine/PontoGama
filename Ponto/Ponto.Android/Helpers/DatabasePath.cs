using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ponto.Base.Data.Interface;
using Ponto.Droid.Helpers;
using System;
using System.IO;


[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Ponto.Droid.Helpers
{
    public class DatabasePath:IDBPath
    {
        public DatabasePath()
        {

        }

        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Ponto.db3");
        }
    }
}