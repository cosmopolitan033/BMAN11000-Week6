using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private int[] playersnumber = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        public Page1()
        {
            InitializeComponent();
            Picker1.ItemsSource = playersnumber;
            if(App.nPlayers > 0)
            {
                Picker1.IsEnabled = false;
                Picker1.SelectedIndex = App.nPlayers - 2;
                ListView2.ItemsSource = App.PlayerItem;
            }
        }

        private void Picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Picker1.SelectedIndex == -1) || (App.nPlayers > 0))
            {
                return;
            }
            App.nPlayers = Picker1.SelectedIndex + 2;
            Picker1.IsEnabled = false;
            App.PlayerItem = new PlayerItem[App.nPlayers];
            for (int i = 0; i < App.nPlayers; i++)
            {
                App.PlayerItem[i] = new PlayerItem();
                App.PlayerItem[i].name = "Player " + Convert.ToString(i + 1);
                App.PlayerItem[i].description = "Name of Player" + Convert.ToString(i + 1);
                ListView2.ItemsSource = App.PlayerItem;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.nPlayers = 0;
            App.PlayerItem = null;
            Picker1.SelectedIndex = -1;
            Picker1.IsEnabled = true;
            ListView2.ItemsSource = null;
            App.MatchItem = null;
        }
    }
    public class PlayerItem
    {
        public string name { get; set; }
        public string description { get; set; }

        public int score { get; set; }
    }
}