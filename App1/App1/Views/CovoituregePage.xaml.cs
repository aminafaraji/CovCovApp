using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Models;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CovoituregePage : ContentPage
	{
		public CovoituregePage ()
		{
			InitializeComponent ();
		}

        private async void NavigateToAddNewIdea_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewCovPage());
        }

        private async void IdeasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var cov = e.Item as Covoiturage;
            //await Navigation.PushAsync(new EditCovPage(cov));
        }

        private async void NavigateToSearchCov_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}