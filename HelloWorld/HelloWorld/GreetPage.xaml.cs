using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class GreetPage : ContentPage
    {
        public GreetPage()
        {
            InitializeComponent();
            slider.Value = 0.5;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Title","Hello World","OK");
        }

        /*void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            label.Text = String.Format("Value is {0:F2}", e.NewValue); 
        }*/
    }
}
