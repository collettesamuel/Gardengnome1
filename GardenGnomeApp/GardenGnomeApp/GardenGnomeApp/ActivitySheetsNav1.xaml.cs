using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenGnomeApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActivitySheetsNav1 : ContentPage
	{
		public ActivitySheetsNav1 ()
		{
			InitializeComponent ();
		}
        async void ActivitySheets2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivitySheetsNav2());
        }
    }
}