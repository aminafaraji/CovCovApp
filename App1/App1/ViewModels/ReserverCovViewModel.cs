using App1.Helpers;
using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class ReserverCovViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public Cov Covoiturage { get; set; }

        public ICommand ReserveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (Convert.ToInt32(Covoiturage.Nombre_de_place) == 0)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", "La covoiturage a expirée", "OK");
                    }

                    int c= Convert.ToInt32(Covoiturage.Nombre_de_place);
                    c--;
                    Covoiturage.Nombre_de_place = c.ToString();

                    await _apiServices.PutIdeaAsync(Covoiturage, Settings.AccessToken);

                   


                });
            }
        }

       

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = string.Empty;
                    Debug.WriteLine(Settings.Username);
                    Settings.Username = string.Empty;
                    Debug.WriteLine(Settings.Password);
                    Settings.Password = string.Empty;

                    // navigate to LoginPage
                });
            }
        }
    }
}
