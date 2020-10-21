using App1.Helpers;
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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

       
             private async void ValidateRegi(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new LoginPage());

            /** if (Settings.RegisterIsSuccess.Equals("Ok"))

             { await Navigation.PushAsync(new LoginPage()); }

             else
             {
                 await DisplayAlert("Ops", "L'inscription a echoué", "OK");
             } **/

        }

    }
}