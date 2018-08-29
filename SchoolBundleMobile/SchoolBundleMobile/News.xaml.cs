using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchoolBundleMobile.Models;
using Xamarin.Forms;

namespace SchoolBundleMobile
{
    public partial class News : ContentPage
    {
        private List<POCArticle> lst = new List<POCArticle>();
        private POCArticle selectedPocArticle;
        public News(POCArticle selectedPocArticle)
        {
            InitializeComponent();
            this.selectedPocArticle = selectedPocArticle;
            BindingContext = this.selectedPocArticle;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lst.Add(this.selectedPocArticle);
            lstNews.ItemsSource = lst;
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>" + this.selectedPocArticle.Description +
                              "</body></html>";
            webView.Source = htmlSource;
        }
    }
}
