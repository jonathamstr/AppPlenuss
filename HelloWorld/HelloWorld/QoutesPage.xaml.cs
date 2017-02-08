using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class QoutesPage : ContentPage
    {   int pos = 0;
        String[] qoutes = { "Most good programmers do programming not because they expect to get paid or get adulation by the public, but because it is fun to program.",
                "To iterate is human, to recurse divine.",
                "The trouble with programmers is that you can never tell what a programmer is doing until it’s too late." };
        public QoutesPage()
        {
            InitializeComponent();
            qouteLabel.Text = qoutes[pos];

        }

        private void nextItem(object source,EventArgs e)
        {   pos = (pos + 1) % 3;
            qouteLabel.Text = qoutes[pos];
            
        }
    }
}
