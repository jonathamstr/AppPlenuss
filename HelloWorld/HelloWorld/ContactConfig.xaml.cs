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
    public partial class ContactConfig : ContentPage
    {
        public User Contacto { get; set; }
        public ContactConfig(User contacto)
        {
            Contacto = contacto;
            InitializeComponent();
            if (contacto != null)
            {
                fName.Text = Contacto.Name.Split(' ')[0];
                lName.Text = Contacto.Name.Split(' ')[1];
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lName.Text) || string.IsNullOrWhiteSpace(fName.Text))
            {
                DisplayAlert("Error", "Llene nombres", "Ok");
            }
            else
            {
                Contacto.Name = fName.Text + " " + lName.Text;
            }

        }
    }
}
