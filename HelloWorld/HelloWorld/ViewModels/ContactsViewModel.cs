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
    class ContactsViewModel : BaseViewModel
    {
        private SQLiteAsyncConnection _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        public ObservableCollection<ContactViewModel> Contacts { get; private set; }
        private ContactViewModel _selectedContact;
        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
           
        }


        public ICommand AddContactoCommand { get; private set; }
        public ICommand SelectContactCommand { get; private set; }

        private readonly IPageService _pageService;
        public ContactsViewModel(IPageService pageService)
        {
            _pageService = pageService;

            AddContactoCommand = new Command<ContactViewModel>(async vm => await AddContact(vm));
        }

        private async Task AddContact(ContactViewModel contacto)
        {   
            await _connection.InsertAsync(contacto);
            Contacts.Add(contacto);
        }


        private async Task SelectContact(ContactViewModel contacto)
        {
            if (contacto == null)
                return;

            SelectedContact = null;
            await _pageService.PushAsync(new ContactDetail(contacto));



        }

        async public void OnAppering()
        {
            await _connection.CreateTableAsync<Contact>();
            var contacts = await _connection.Table<Contact>().ToListAsync();
            Contacts = new ObservableCollection<Contact>(contacts);
        }
    }
}
