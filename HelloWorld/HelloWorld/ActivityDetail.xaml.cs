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
    public partial class ActivityDetail : ContentPage
    {
        public Activity actividad;
        User usuario;
        public ActivityDetail(Activity act)
        {
            if (act == null)
                throw new ArgumentNullException();

            
            InitializeComponent();
            BindingContext = act;
            usuario = UserService.GetUser(act.UserId);
            Title = usuario.Name;

            actividad = act;
            Titulo.Text = usuario.Name;
        }
    }
}
