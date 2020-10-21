using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using App1.Helpers;
using App1.Models;
using App1.Services;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class CovoituragesViewModels : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();

        //public string AccessToken { get; set; }

        //public List<Covoiturage> Covoiturages { get; set; }

        private List<Covoiturage> _covoiturages;

        //public string AccessToken { get; set; }
        public List<Covoiturage> Covoiturage
        {
            get { return _covoiturages; }
            set
            {
                _covoiturages = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetCovoiturage

        {
            get
            {

                return new Command(async () =>

                {
                    var accessToken = Settings.AccessToken;
                    Covoiturage =   await _apiServices.GetCovoituragesAsync(accessToken);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
