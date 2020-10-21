using System;
using System.Collections.Generic;
using System.Text;

using App1.Services;
using App1.Helpers;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Messaging;
using App1.Views;

namespace App1.ViewModels
{
   public class RegisterViewModel
    {

        
        ApiServices _apiServices = new ApiServices();



        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand

        {
            get
            {

                return new Command(async() =>

                {

                    Message = "cc";
                     var isSucces = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);

                    
                    Settings.Username = Email;
                    Settings.Password = Password;

                    if (isSucces)
                    {
                        Message = "Registered success";
                        Settings.RegisterIsSuccess = "Ok";
                        await Application.Current.MainPage.DisplayAlert("Good!", "Registered success", "OK");
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }


                    else
                    {
                        Message = "Retry later";
                        Settings.RegisterIsSuccess = "Non";

                        //
                        await Application.Current.MainPage.DisplayAlert("Ops", "Retry later", "OK");
                    }



                });

               
            }

           
        }

       
    }
}
