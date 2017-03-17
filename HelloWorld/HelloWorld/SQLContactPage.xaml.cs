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
    public partial class SQLContactPage : ContentPage
    {
        public SQLContactPage()
        {
            ViewModel = new ContactsViewModel(new PageService());
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            
        }


        private ContactsViewModel ViewModel
        {
            get { return BindingContext as ContactsViewModel; }
            set { BindingContext = value; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
