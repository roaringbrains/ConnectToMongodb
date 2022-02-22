using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;

namespace ConnectToMongodb.Droid
{
    [Activity(Label = "ConnectToMongodb", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            string dbname = "trader_alpha";

            //string dbmongo = "mongodb+srv://server:serverKey@cluster0.9wiad.mongodb.net/Test?retryWrites=true&w=majority";
            string dbmongo = "mongodb://server:serverKey@cluster0-shard-00-00.9wiad.mongodb.net:27017,cluster0-shard-00-01.9wiad.mongodb.net:27017,cluster0-shard-00-02.9wiad.mongodb.net:27017/Test?ssl=true&replicaSet=atlas-oqk7u2-shard-0&authSource=admin&retryWrites=true&w=majority";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderPath, dbname);
            LoadApplication(new App(fullpath,dbmongo));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}