using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchoolBundleMobile.Models;
using Xamarin.Forms;

namespace SchoolBundleMobile
{
    public partial class News : ContentPage
    {
        //private List<POCArticle> lst = new List<POCArticle>();
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
            /*lst.Add(this.selectedPocArticle);
            lstNews.ItemsSource = lst;*/

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>" + this.selectedPocArticle.Description +
                              "</body></html>";
            webView.Source = htmlSource;
            if (slCategories.Children.Count > 0)
            {
                for (int i = 0; i < slCategories.Children.Count; i++)
                    slCategories.Children.RemoveAt(i);
            }
            if (slLinks.Children.Count > 0)
            {
                for (int i = 0; i < slLinks.Children.Count; i++)
                    slLinks.Children.RemoveAt(i);
            }
            if (slAttachments.Children.Count > 0)
            {
                for (int i = 0; i < slAttachments.Children.Count; i++)
                    slAttachments.Children.RemoveAt(i);
            }
            StackChildren();
        }

        void StackChildren()
        {
            var newsfeedcategories = this.selectedPocArticle.Newsfeedcategories;
            if (newsfeedcategories != null)
            {
                foreach (var item in newsfeedcategories)
                {
                    //< Label Text = "{Binding Title}" TextColor = "#111111" FontSize = "14" FontFamily = "Segoe UI" Opacity = "100" />
                    var label = new Label
                    {
                        Text = item.CategoryName,
                        TextColor = Color.FromHex("#111111"),
                        FontSize = 14,
                        FontFamily = "Segoe UI",
                        Opacity = 100
                    };
                    slCategories.Children.Add(label);
                }
            }

            var links = this.selectedPocArticle.Links;
            if (links != null)
            {
                foreach (var item in links)
                {
                    Label label = new Label
                    {
                        Text = item.LinkTitle,
                        TextColor = Color.FromHex("#0073AE"),
                        FontSize = 14,
                        FontFamily = "Segoe UI",
                        Opacity = 100
                    };

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        Device.OpenUri(new Uri(item.LinkUrl));
                    };
                    label.GestureRecognizers.Add(tapGestureRecognizer);
                    slLinks.Children.Add(label);
                }
            }

            var attachments = this.selectedPocArticle.Attachments;
            if (attachments != null)
            {
                foreach (var item in attachments)
                {
                    //<Image  Source="attachment.png" HorizontalOptions="Start" WidthRequest="16" HeightRequest="18"  Opacity="100"/>
                    //Create horizonal stack
                    var stackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };
                    var image = new Image
                    {
                        Source = ImageSource.FromFile("pdf.png"),
                        HorizontalOptions = LayoutOptions.Start,
                        WidthRequest = 16,
                        HeightRequest = 18,
                        Opacity = 100
                    };
                    Label label = new Label
                    {
                        Text = item.FileDisplayName,
                        TextColor = Color.FromHex("#0073AE"),
                        FontSize = 14,
                        FontFamily = "Segoe UI",
                        Opacity = 100
                    };

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        Device.OpenUri(new Uri(item.UniqueFileName));
                    };
                    label.GestureRecognizers.Add(tapGestureRecognizer);

                    stackLayout.Children.Add(image);
                    stackLayout.Children.Add(label);
                    slAttachments.Children.Add(stackLayout);
                }
            }


        }
    }
}
