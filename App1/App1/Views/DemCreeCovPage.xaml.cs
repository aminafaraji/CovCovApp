using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DemCreeCovPage : ContentPage
	{
		public DemCreeCovPage ()
		{
			InitializeComponent ();
		}

        private async void NavigateToSearchCov_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void NavigateAddNewCovCov_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewCovPage());
        }

        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}