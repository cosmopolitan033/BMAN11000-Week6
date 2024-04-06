using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Week6
{
    public partial class App : Application
    {
        public static int nPlayers;
        public static PlayerItem[] PlayerItem;
        public static MatchItem[] MatchItem;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            Application.Current.Properties["nPlayers"] = App.nPlayers;
            string s;
            s = JsonConvert.SerializeObject(App.PlayerItem);
            Application.Current.Properties["playerItems"] = s;
            s = JsonConvert.SerializeObject(App.MatchItem);
            Application.Current.Properties["matchItems"] = s;

        }

        protected override void OnResume()
        {
            if (Application.Current.Properties.ContainsKey("nPlayers"))
            {
                App.nPlayers = (int)Application.Current.Properties["nPlayers"];
            }
            if (Application.Current.Properties.ContainsKey("playerItems"))
            {
                string s = (string)Application.Current.Properties["playerItems"];
                App.PlayerItem = JsonConvert.DeserializeObject<PlayerItem[]>(s);
            }
            if (Application.Current.Properties.ContainsKey("matchItems"))
            {
                string s = (string)Application.Current.Properties["matchItems"];
                App.MatchItem = JsonConvert.DeserializeObject<MatchItem[]>(s);
            }
        }
    }
}


