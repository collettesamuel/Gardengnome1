using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenGnome1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayGame : ContentPage
	{
		public PlayGame ()
		{
			InitializeComponent ();
		}

        async void PlayTicTacToe(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicTacToe());
        }

        async void PlayMemoryGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MemoryGame());
        }

        async void PlaySpotThePlant(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpotThePlant());
        }
    }

}