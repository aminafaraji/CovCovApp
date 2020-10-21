using App1.Helpers;
using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCovPage : ContentPage
	{
		public EditCovPage (Cov cov)
		{
            var editCovViewModel = new EditCovViewModel();
            editCovViewModel.Covoiturage = cov ;

            BindingContext = editCovViewModel;


            InitializeComponent ();

           // var editCovViewModel = BindingContext as EditCovViewModel;

           // editCovViewModel.Covoiturage = cov

        }



             private async void ToMap(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());

            getLocation();

        }

        async void getLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Settings.Latitude = location.Latitude.ToString();
                    Settings.Longitude = location.Longitude.ToString();
                   


                    await Navigation.PushAsync(new Map());

                    // await DisplayAlert("Ops", $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}", "OK");
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}