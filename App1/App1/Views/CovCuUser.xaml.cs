using App1.Models;
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
	public partial class CovCuUser : ContentPage
	{
		public CovCuUser ()
		{
			InitializeComponent ();
		}

        private async void CovListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var cov = e.Item as Cov;
            await Navigation.PushAsync(new EditCovPage(cov));
        }

        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}