using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Essentials;

namespace App1.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        // #region Setting Constants

        //private const string SettingsKey = "settings_key";
        //private static readonly string SettingsDefault = string.Empty;

        //#endregion


        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static string UserLogOk
        {
            get
            {
                return AppSettings.GetValueOrDefault("UserLogOk", "null");
            }
            set
            {
                AppSettings.AddOrUpdateValue("UserLogOk", value);
            }
        }

        public static string RegisterIsSuccess
        {
            get
            {
                return AppSettings.GetValueOrDefault("RegisterIsSuccess", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("RegisterIsSuccess", value);
            }
        }


        public static DateTime AccessTokenExpirationDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessTokenExpirationDate", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessTokenExpirationDate", value);
            }
        }

        public static string Latitude
        {
            get
            {
                return AppSettings.GetValueOrDefault("Latitude", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Latitude", value);
            }
        }

        public static string Longitude
        {
            get
            {
                return AppSettings.GetValueOrDefault("Longitude", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Longitude", value);
            }
        }

    }
}
