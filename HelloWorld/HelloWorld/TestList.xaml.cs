using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class TestList : ContentPage
    {
        public TestList()
        {
            InitializeComponent();


            listView.ItemsSource = new List<ContactGroup>
            {
                new ContactGroup("M","M")
                {
                    new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1", Status = "Hey" }
                },
                new ContactGroup("K","K")
                {
                    new Contact { Name = "Kate", ImageUrl = "http://lorempixel.com/100/100/people/3", Status = "Hola" }
                },
                new ContactGroup("J","J")
                {
                    new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "Salut" }
                },

                
                
            };
        }
    }
}
