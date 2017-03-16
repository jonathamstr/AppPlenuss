using HelloWorld.Services;
using Java.Net;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace HelloWorld
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class Producto
    {
        public string id { get; set; }
        public string desc1 { get; set; }
        public string producto { get; set; }
    }

    public class Recipe : INotifyPropertyChanged
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        private string _name;

        [MaxLength(255)]
        public string Name {
            get { return _name;  }
            set {
                if (_name == value)
                    return;
                _name = value;

                OnPropertyChanged();
            }
        }
        
        private void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
         
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public partial class MainPage : ContentPage
	{

        private const string Url = "http://192.168.1.68:8000";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<string> _tablas;
        private ObservableCollection<Producto> _productos;
        private ObservableCollection<Recipe> _recipes;
        public string MyIp = "";


        private SQLiteAsyncConnection _connection;
        public MainPage()
		{
            //ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            InitializeComponent();


            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            postListView.ItemsSource = _recipes;

            //var content = await _client.GetStringAsync(Url+"/pprod");
            //var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            //var tablas = JsonConvert.DeserializeObject<List<string>>(content);
            //var productos = JsonConvert.DeserializeObject<List<Producto>>(content);
            //_posts = new ObservableCollection<Post>(posts);
            //postListView.ItemsSource = _posts;
            //_tablas = new ObservableCollection<string>(tablas);
            //_productos = new ObservableCollection<Producto>(productos);
            //postListView.ItemsSource = _productos;
            //System.Diagnostics.Debug.WriteLine("Hola1111111111111111111111111111111111");

            base.OnAppearing();
        }
       async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe" + DateTime.Now.Ticks };
            await _connection.InsertAsync(recipe);
            _recipes.Add(recipe);
/*            var post = new Post { Title = "Title" + DateTime.Now.Ticks };

            var content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url, new StringContent(content));
            _posts.Insert(0, post);*/
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += " UPDATED";

            await _connection.UpdateAsync(recipe);
           
            /*var post = _posts[0];
            post.Title += " UPDATED";

            var content = JsonConvert.SerializeObject(post);
            await _client.PutAsync(Url + "/" + post.Id, new StringContent(content));*/
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            await _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
/*            var post = _posts[0];

            _posts.Remove(post);
            await _client.DeleteAsync(Url + "/" + post.Id);
            */

        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var producto = e.SelectedItem as Producto;
            Navigation.PushAsync(new DetalleProducto(producto));
        }
    }
}

