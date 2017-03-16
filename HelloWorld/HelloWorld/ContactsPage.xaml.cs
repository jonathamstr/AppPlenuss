using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        List<User> usuarios;
        public ContactsPage()
        {
            usuarios = new List<User>();
            usuarios.Add(new User(1, "Jonathan Aguirre", "Crazy dude"));
            usuarios.Add(new User(2, "Rodolfo Garcia", "Programmer"));
            InitializeComponent();
            lista.ItemsSource = usuarios;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactConfig(null));
            lista.SelectedItem = null;
        }

        private async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var contacto = e.SelectedItem as User;
            await Navigation.PushAsync(new ContactConfig(contacto));
            lista.SelectedItem = null;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            usuarios.Remove(sender as User);
            lista.ItemsSource = usuarios;
        }
    }
}
