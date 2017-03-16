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
    public partial class ActivityPage : ContentPage
    {
        List<Activity> activities;
        public ActivityPage()
        {
            InitializeComponent();
            activities = ActivityService.GetActivities();
            lista.ItemsSource = activities;
        }

        private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var activity = e.SelectedItem as Activity;
            Navigation.PushAsync(new ActivityDetail(activity));
            //lista.SelectedItem = null;
        }
    }
}
