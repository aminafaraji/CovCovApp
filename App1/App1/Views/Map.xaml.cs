using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Helpers;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Map : ContentPage
	{
		public Map()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            MainMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(double.Parse(Settings.Latitude), double.Parse(Settings.Longitude)),
                Distance.FromKilometers(5)));

            var pin = new Pin
            {
                Position = new Position(double.Parse(Settings.Latitude), double.Parse(Settings.Longitude)),
                Label = "Position #1",
                Address = "Address #1"
            };

            MainMap.Pins.Add(pin);

            var pin2 = new Pin
            {
                Position = new Position(33.5293, -7.6404),
                Label = "Position #1",
                Address = "Address #1"
            };

            MainMap.Pins.Add(pin2);




            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Red,
                StrokeWidth = 5,
                Geopath =
    {
        new Position(double.Parse(Settings.Latitude), double.Parse(Settings.Longitude)),
        new Position(33.5293,-7.6404)
    }
            };

            // add the polyline to the map's MapElements collection
            MainMap.MapElements.Add(polyline);
        }
    }
}