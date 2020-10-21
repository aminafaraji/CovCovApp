using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace App1.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Xamarin.FormsMaps.Init("6akcwoSlU8DSxplNB0lv~AutwJpUQ2uLsyAyPKKmcaA~Ar5YrL3SwtOgmYoYDwupApd8OLzKG97hxX55so0HTr8xAd_SXRr_Vhiyx7jEoVf9");
            LoadApplication(new App1.App());
        }
    }
}
