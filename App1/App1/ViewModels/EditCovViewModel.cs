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
   public class EditCovViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public Cov Covoiturage { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.PutIdeaAsync(Covoiturage, Settings.AccessToken);
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.DeleteCovAsync(Covoiturage.Id, Settings.AccessToken);
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
