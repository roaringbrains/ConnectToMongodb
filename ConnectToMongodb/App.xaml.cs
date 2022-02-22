using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConnectToMongodb
{
    public partial class App : Application
    {
        public static string DatabaseLaction = string.Empty;
        public static string DatabaseMongo = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public App(string database, string databasem )
        {
            InitializeComponent();

            MainPage = new MainPage();
            DatabaseLaction = database;
            DatabaseMongo = databasem;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
