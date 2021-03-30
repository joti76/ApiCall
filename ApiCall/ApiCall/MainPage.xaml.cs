using ApiCall.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApiCall
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
            ApiHelper.InitializeClient();

        }

        private async Task LoadImage()
        {
            DogModel dog;
            do
            {
              dog = await ImgProcessor.LoadDogImage();
            } while (dog.Url.Contains(".mp4"));

        

            var uriSource = new Uri(dog.Url, UriKind.Absolute);
            Console.WriteLine($"uriSource: {uriSource}");
            //dogImage.Source = "https://random.dog/c6b91a3b-9fa3-457b-9ed5-ffb8b988bdfe.jpg";
            dogImage.Source = uriSource;


        }

        //private async void Window_Loaded(object sender, RoutedEventArgs e)
        //{
         //   await LoadImage();
       // }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //your code here;
            await LoadImage();
        }

        private async void randomImageButton_Clicked(object sender, EventArgs e)
        {
            await LoadImage();
        }
    }
}
