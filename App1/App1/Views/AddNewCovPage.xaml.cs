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
	public partial class AddNewCovPage : ContentPage
	{
		public AddNewCovPage ()
		{
			InitializeComponent ();
		}

        private async void ToMesCov(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CovCuUser());
        }

        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}