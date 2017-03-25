using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld.ViewModels 
{
    class PageService : IPageService
    {
       

        public async Task DisplayAlertAsync(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok
                );
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage;  }
        }
    }
}
