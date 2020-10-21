using App1.Helpers;
using App1.Services;
using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using App1.Views;

namespace App1.ViewModels
{
   public class LoginViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand

        {
            get
            {

                return new Command(async () =>

                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);
                    Settings.AccessToken = accesstoken;

                    if (accesstoken == null)
                    {
                        Settings.UserLogOk = "Non";
                        await Application.Current.MainPage.DisplayAlert("Ops", "Mot de passe ou Email erroné", "OK");
                    }
                    else
                    {
                        Settings.UserLogOk = "Ok";
                        
                        await Application.Current.MainPage.Navigation.PushAsync(new CreProCov());
                        //await Application.Current.MainPage.Navigation.PushAsync(new  DemCreeCovPage);
                    }
                    

                });
            }
        }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }


    }
}
