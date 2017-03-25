using HelloWorld.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class ContactDetailViewModel
    {

        private readonly IContactStore _contactStore;
        private readonly IPageService _pageService;

        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        public Contact Contact { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public  ContactDetailViewModel(ContactViewModel viewModel, IContactStore contactStore, IPageService pageService)
        {

            if (viewModel == null)
                throw new ArgumentNullException();

            _pageService = pageService;
            _contactStore = contactStore;

            SaveCommand = new Command(async () => await Save());
                Contact = new Contact
                {
                    Id = viewModel.id,
                    FirstName = viewModel.firstName,
                    LastName = viewModel.lastName,
                    Phone = viewModel.Phone,
                    Email = viewModel.Email,
                    IsBlocked = viewModel.blocked
                };
        }

        async Task Save()
        {
            
            if (String.IsNullOrWhiteSpace(Contact.FirstName) &&
                String.IsNullOrWhiteSpace(Contact.LastName))
            {
                await _pageService.DisplayAlertAsync("Error", "Please enter the name", "Ok");
                return;
            }
            await _pageService.DisplayAlertAsync("Entro", "Si sale", "Ok");
            if (Contact.Id == 0)
            {
                await _pageService.DisplayAlertAsync("Entro", Contact.FirstName + " " + Contact.LastName , "Ok");
                await _contactStore.AddContactAsync(Contact);
                ContactAdded?.Invoke(this, Contact);
            }
            else
            {
                await _contactStore.UpdateContactAsync(Contact);
                ContactUpdated?.Invoke(this, Contact);
            } 

            await _pageService.PopAsync();
        }
    }
}
