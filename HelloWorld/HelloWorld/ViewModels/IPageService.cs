using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    interface IPageService
    {
        Task PushAsync(Page page);
        Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel);

    }
}
