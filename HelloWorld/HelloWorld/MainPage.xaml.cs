using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

namespace HelloWorld
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    public partial class MainPage : ContentPage
	{

        private const string Url = "http://192.168.1.68:8000/tables";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<string> _tablas;
        public MainPage()
		{
            //ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            //var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            var tablas = JsonConvert.DeserializeObject<List<string>>(content);
            //_posts = new ObservableCollection<Post>(posts);
            //postListView.ItemsSource = _posts;
            _tablas = new ObservableCollection<string>(tablas);
            postListView.ItemsSource = _tablas;
            //System.Diagnostics.Debug.WriteLine("Hola1111111111111111111111111111111111");

            base.OnAppearing();
        }
       async void OnAdd(object sender, System.EventArgs e)
        {
/*            var post = new Post { Title = "Title" + DateTime.Now.Ticks };

            var content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url, new StringContent(content));
            _posts.Insert(0, post);*/
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {

                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();

            if (result != null)
             await   DisplayAlert(result.Text, "Resultado", "Ok");  
           
            /*var post = _posts[0];
            post.Title += " UPDATED";

            var content = JsonConvert.SerializeObject(post);
            await _client.PutAsync(Url + "/" + post.Id, new StringContent(content));*/
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
/*            var post = _posts[0];

            _posts.Remove(post);
            await _client.DeleteAsync(Url + "/" + post.Id);
            */

        }

    }
}

