using HelloWorld.Persistance;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {

        private ContactViewModel _selectedContact;
        public IContactStore _contactStore;
        public IPageService _pageService;
        private bool _isDataLoaded;


        public ObservableCollection<ContactViewModel> Contacts { get; private set; } = new ObservableCollection<ContactViewModel>();

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
           
        }


        public ICommand AddContactoCommand { get; private set; }
        public ICommand SelectContactCommand { get; private set; }
        public ICommand LoadDataCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactsViewModel(IContactStore contactStore ,IPageService pageService)
        {
            _pageService = pageService;
            _contactStore = contactStore;

            LoadDataCommand = new Command(async () => await LoadData());
            AddContactoCommand = new Command(async () => await AddContact());
            SelectContactCommand = new Command<ContactViewModel>(async c => await SelectContact(c));
            DeleteContactCommand = new Command<ContactViewModel>(async c => await DeleteContact(c));
            
        }

        
        private async Task LoadData()
        {
           
           if (_isDataLoaded)
                return;
            _isDataLoaded = true;
            
            var contacts = await _contactStore.getContactsAsync();
            
            foreach (var c in contacts)
            {
                var contacto = new ContactViewModel();
                Contacts.Add(contacto);
            } 
            
        }


        
        private async Task AddContact()
        {
          
                ContactDetailViewModel viewModel = new ContactDetailViewModel(new ContactViewModel(), _contactStore, _pageService);
            
            viewModel.ContactAdded += async (source, contact) =>
            {
                await _pageService.DisplayAlertAsync("Objecto Registrado", contact.FirstName + contact.LastName + contact.Id, "Vale");
                Contacts.Add(new ContactViewModel(contact));
            };
            await _pageService.PushAsync(new ContactDetail(viewModel));
        }

        private void ViewModel_ContactAdded(object sender, Contact e)
        {
            Contacts.Add(new ContactViewModel(e));
        }

        private async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            var viewModel = new ContactDetailViewModel(contact, _contactStore, _pageService);
            viewModel.ContactUpdated += (source, updatedContact) =>
            {
                contact.id = updatedContact.Id;
                contact.firstName = updatedContact.FirstName;
                contact.lastName = updatedContact.LastName;
                contact.Phone = updatedContact.Phone;
                contact.Email = updatedContact.Email;
                contact.blocked = updatedContact.IsBlocked;
            };

            await _pageService.PushAsync(new ContactDetail(viewModel));
        }

        private async Task DeleteContact(ContactViewModel contactViewModel)
        {
            var a = "";
            await _pageService.DisplayAlertAsync("hey", "how you", "doing");
            if(await _pageService.DisplayAlertAsync("Warning",$"Arre you sure you want to delete {contactViewModel.FullName} ?","Yes","No"))
            {
                Contacts.Remove(contactViewModel);

                var contact = await _contactStore.getContactAsync(contactViewModel.id);
                await _contactStore.DeleteContactAsync(contact);
            }
        }
    }
}
