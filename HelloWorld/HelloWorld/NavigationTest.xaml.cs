using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class NavigationTest : ContentPage
    {
        public NavigationTest()
        {
            InitializeComponent();
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
