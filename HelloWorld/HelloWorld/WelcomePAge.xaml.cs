using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class WelcomePAge : ContentPage
    {
        public WelcomePAge()
        {
            InitializeComponent();
        }

        async void ClickedEvent(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NavigationTest()); 
        }
    }
}
