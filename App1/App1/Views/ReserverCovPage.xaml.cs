using App1.Helpers;
using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReserverCovPage : ContentPage
	{
		public ReserverCovPage (Cov cov)
		{
            var reserverCovViewModel = new ReserverCovViewModel();
            reserverCovViewModel.Covoiturage = cov;

            BindingContext = reserverCovViewModel;

            
            InitializeComponent ();
		}

        private async void EnvoyerMail(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("covcov874@gmail.com");
                mail.To.Add(Settings.Username);
                mail.Subject = "Bonjour!";
                mail.Body = "La réservation a été faite avec succès";   

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("covcov874@gmail.com", "A8jSMb8a");
                SmtpServer.Send(mail);

            }

            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }
        }

    }
}