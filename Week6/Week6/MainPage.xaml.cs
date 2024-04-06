using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week6
{
    public partial class MainPage : ContentPage
    {
        public MainpagesItem[] mpi;
        public MainPage()
        {
            InitializeComponent();
            mpi = new MainpagesItem[3];
            mpi[0] = new MainpagesItem { title = "Players", description ="SpecifyPlayers"};
            mpi[1] = new MainpagesItem { title = "Matches", description = "Track results of matches" };
            mpi[2] = new MainpagesItem { title = "Achievements", description = "See players' achievements" };
            ListView1.ItemsSource = mpi;
        }

        private void ListView1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MainpagesItem item = (MainpagesItem)e.Item;
            if (item.title == "Players")
            {
                Page1 p = new Page1();
                Navigation.PushAsync(p);
            }

            else if(item.title == "Matches")
            {
                MatchesPage p = new MatchesPage();
                Navigation.PushAsync(p);
            }

            else
            {
                if (App.nPlayers == 0)
                {
                    DisplayAlert("Alert","Player information has not been provided.", "OK");
                }
            }
        }
    }
    public class MainpagesItem
    {
        public string title { get; set; }
        public string description { get; set; }
    }
}
