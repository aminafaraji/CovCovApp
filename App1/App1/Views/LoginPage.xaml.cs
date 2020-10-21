using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Views;
using App1.Helpers;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void NavigateToCovoituragePage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CovoituregePage());
        }

        private async void LoginTO_Clicked(object sender, EventArgs e)
        {

           /** if (Settings.UserLogOk.Equals("Non"))
            { Settings.UserLogOk = "";
              await DisplayAlert("Ops", "Mot de passe ou Email erroné", "OK");
                
            }

            else {
                if (Settings.UserLogOk.Equals("Ok")) {
                    Settings.UserLogOk = "";
                    await Navigation.PushAsync(new DemCreeCovPage()); }

                else await DisplayAlert("Ops", "problem", "OK");
            }**/

        }

        private async void NavigateToMapPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Map());
        }
        

    }
}