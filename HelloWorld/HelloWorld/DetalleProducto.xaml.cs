using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class DetalleProducto : ContentPage
    {
        public DetalleProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException();

            BindingContext = producto;
            InitializeComponent();
        }
    }
}
