using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Services;
using Xamarin.Forms;
using App1.Models;
using App1.Helpers;
using System.Globalization;
using System.Diagnostics;

namespace App1.ViewModels
{
   public class AddNewCovViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string Depart { get; set; }
        public string Arrivee { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Horaire { get; set; }
        public string Nombre_de_place { get; set; }


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

                    Settings.UserLogOk = null;
                    

                    // navigate to LoginPage
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {

                    

                    var cov = new Cov
                    {
                        Depart = "casablanca nearshore park, 1100 , boulevard al quods, quartier sidi maarouf, casablanca 20190, maroc",
                        Arrivee = Arrivee,
                        Nombre_de_place = Nombre_de_place,
                        Date = Date.ToString("D",CultureInfo.CreateSpecificCulture("en-US")),
                        Horaire = Horaire.ToString()

                        
                        
                    };
 
                    await _apiServices.PostCovAsync(cov, Settings.AccessToken);

                });
            }
        }


    }
}
