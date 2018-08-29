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
	public partial class Home : ContentPage
	{
	    private HttpClient client = new HttpClient();
        public Home()
		{
			InitializeComponent();
		}

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();

	        /*client.MaxResponseContentBufferSize = 256000;
	        int _TimeoutSec = 90;
	        client.Timeout = new TimeSpan(0, 0, _TimeoutSec);
	        string _ContentType = "application/json";
	        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
	        var uri = new Uri("https://ci-webapi-m-poc.azurewebsites.net/api/pocarticle");
	        HttpRequestMessage msgToGet = new HttpRequestMessage(HttpMethod.Get, uri);
            //my custom headers
	        msgToGet.Headers.Add("X_APPID", Constants.X_APPID);
	        msgToGet.Headers.Add("X_CUSTID", Constants.X_CUSTID);
	        msgToGet.Headers.Add("X_USERTOKEN", Constants.X_USERTOKEN);
	        msgToGet.Headers.Add("X_MVCHOST", Constants.X_MVCHOST);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
	        content.Headers.ContentType = new MediaTypeHeaderValue(_ContentType);
	        msgToGet.Content = content;
	        HttpResponseMessage response;
	        response = client.SendAsync(msgToGet).Result;
	        String execResult = response.ReasonPhrase; */

            var response = await client.GetAsync("https://ci-webapi-m-poc.azurewebsites.net/api/pocarticle");
	        var json = await response.Content.ReadAsStringAsync();
            //var jsonData = JsonConvert.DeserializeObject<List<POCArticle>>(content);

        }
	}
}
