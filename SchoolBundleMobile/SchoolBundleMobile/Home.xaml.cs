using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SchoolBundleMobile.Helpers;
using SchoolBundleMobile.Models;
using Xamarin.Forms;

namespace SchoolBundleMobile
{
    public partial class Home : TabbedPage
    {
        private HttpClient client = new HttpClient();

        public Home()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CallBackToRest();

            /*client.BaseAddress = new Uri("https://ci-webapi-m-poc.azurewebsites.net/api/pocarticle");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-appid", Constants.X_APPID);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-custid", Constants.X_CUSTID);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-usertoken", Constants.X_USERTOKEN);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-mvc-host", Constants.X_MVCHOST);
                        
            var response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<POCArticle>>(content);
            } */
            
        }

        async void CallBackToRest()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://ci-webapi-m-poc.azurewebsites.net/api/pocarticle");
            requestMessage.Headers.Add("x-appid", Constants.X_APPID);
            requestMessage.Headers.Add("x-custid", Constants.X_CUSTID);
            requestMessage.Headers.Add("x-usertoken", Constants.X_USERTOKEN);
            requestMessage.Headers.Add("x-mvc-host", Constants.X_MVCHOST);
            //Send the request to the server
            
            HttpResponseMessage response = await client.SendAsync(requestMessage);
            
            string responseAsString = await response.Content.ReadAsStringAsync();
            var lstPOCArticle = JsonConvert.DeserializeObject<List<POCArticle>>(responseAsString);
            lstViewRest.ItemsSource = lstPOCArticle;
        }

        void ArticleRefreshing(object sender, System.EventArgs e)
        {
            CallBackToRest();
            lstViewRest.EndRefresh();
        }

    }
}
