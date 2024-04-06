using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchesPage : ContentPage
    {
        public MatchesPage()
        {
            InitializeComponent();
            if (App.MatchItem == null && App.PlayerItem != null)
            {
                int N = App.nPlayers * (App.nPlayers - 1) / 2;
                App.MatchItem = new MatchItem[N];
                int counter = 0;
                for (int i = 0; i < App.nPlayers; i++)
                    for (int j = i + 1; j < App.nPlayers; j++)
                    {
                        App.MatchItem[counter] = new MatchItem();
                        App.MatchItem[counter].Player1 = App.PlayerItem[i].name;
                        App.MatchItem[counter].Player2 = App.PlayerItem[j].name;
                        counter++;
                    }
            }
            BindableLayout.SetItemsSource(StackLayout1, App.MatchItem);

        }
    }

    public class MatchItem
    {
        public string Player1 {  get; set; }

        public string Player2 { get; set; }

        public double Score1 { get; set; }

        public double Score2 { get; set; }
    }
}