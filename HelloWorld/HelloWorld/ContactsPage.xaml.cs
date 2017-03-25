using HelloWorld.Persistance;
using HelloWorld.ViewModels;
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
       
        public ContactsPage()
        {
            var contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            ViewModel = new ContactsViewModel(contactStore, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {

          ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }

        public ContactsViewModel ViewModel
        {
            get { return BindingContext as ContactsViewModel; }
            set { BindingContext = value; }
        }
    }
}
