using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GardenGnomeApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        async void PlayClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGame());
        }
        async void ActivitySheetsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivitySheetsNav1());
        }
        async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
