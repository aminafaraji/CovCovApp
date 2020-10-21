using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App1.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/Json");

           var response =  await client.PostAsync("http://localhost:51610/api/Account/Register", content);
            return response.IsSuccessStatusCode;                      


        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",username),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:51610/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<JObject>(content);

            var accessToken = jwtDynamic.Value<string>("access_token");
           

            Debug.WriteLine(content);

            return accessToken;

        }

        public async Task<List<Covoiturage>> GetCovoituragesAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            Debug.WriteLine("accessToken : ", accessToken);

            var json =  await client.GetStringAsync("http://localhost:51610/api/Covoiturages");

            var covoiturages = JsonConvert.DeserializeObject<List<Covoiturage>>(json);

            return covoiturages;



        }

      

        public async Task PostCovoiturageAsync(Covoiturage cov, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(cov);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/Json");

            var response = await client.PostAsync("http://localhost:51610/api/Covoiturages", content);


        }

        public async Task PutIdeaAsync(Cov cov, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(cov);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(
                "http://localhost:51610/api/Covoiturage/" + cov.Id, content);


        }

        public async Task DeleteCovAsync(int covId, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync(
                "http://localhost:51610/api/Covoiturage/" + covId);
        }

        public async Task<List<Cov>> SearchCovoituragesAsync(string keyWord , string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            Debug.WriteLine("accessToken : ", accessToken);

            var json = await client.GetStringAsync("http://localhost:51610/api/Covoiturage/Search/" + keyWord);

            var covoiturages = JsonConvert.DeserializeObject<List<Cov>>(json);

            return covoiturages;



        }

        public async Task PostCovAsync(Cov cov, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(cov);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/Json");

            var response = await client.PostAsync("http://localhost:51610/api/Covoiturage", content);


        }

        public async Task<List<Cov>> GetCovoiturageAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        
            Debug.WriteLine("accessToken : ", accessToken);
            var json = await client.GetStringAsync("http://localhost:51610/api/CovCovModels");
            var covoiturages = JsonConvert.DeserializeObject<List<Cov>>(json);
            return covoiturages;
        }

        public async Task<List<Cov>> GetCovoituragesCurrentUserAsync(string accessToken)
        { 
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            Debug.WriteLine("accessToken : ", accessToken);
            var json = await client.GetStringAsync("http://localhost:51610/api/Covoiturage/CurrentUser");
            var covoiturages = JsonConvert.DeserializeObject<List<Cov>>(json);
            return covoiturages;
        }


    }
}
