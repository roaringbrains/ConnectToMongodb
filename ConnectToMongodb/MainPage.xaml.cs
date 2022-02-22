using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConnectToMongodb
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://server:<password>@cluster0.9wiad.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            //settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            //var client = new MongoClient(settings);
            //var database = client.GetDatabase("test");
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient(App.DatabaseMongo);

            var database = dbClient.GetDatabase("Test");
            var collection = database.GetCollection<BsonDocument>("user");

            var document = new BsonDocument { { "name",txtUserName.Text}, { "password",txtPassword.Text} };
            collection.InsertOne(document);

            DisplayAlert("Success", "User Ok!", "Ok");



            if (txtUserName.Text == "admin" && txtPassword.Text == "123")
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Alert", "Username or Password is incorrect!", "Ok");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
