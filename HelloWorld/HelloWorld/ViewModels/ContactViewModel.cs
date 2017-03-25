using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {

        private Contact contacto { set; get; }


        public ContactViewModel() {
            contacto = new Contact();
        }

        public ContactViewModel(Contact contacto)
        {
            this.contacto = contacto;
        }


        public int id {
            get { return contacto.Id; }
            set {
                contacto.Id = value;
                }
        }
        
        
        public  string FullName
        {
            get { return $"{contacto.FirstName} {contacto.LastName}" ; }
        }

        public string Phone {
            get { return contacto.Phone; }
            set {
                contacto.Phone = value;
                }
        }

        public string Email { get
            { return contacto.Email; }
            set
            {
                contacto.Email = value;
            }
        }

        public Boolean blocked {
            get{ return contacto.IsBlocked; }
            set
            {
                contacto.IsBlocked = value;
            }
        }

        public string firstName
        {
            get { return firstName; }
            set
            {
                contacto.FirstName = value;
                OnPropertyChanged(nameof(contacto));
                OnPropertyChanged(nameof(FullName));
            }
        }


        public string lastName
        {
            get { return contacto.LastName; }
            set
            {
                contacto.LastName = value;
                OnPropertyChanged(nameof(contacto));
                OnPropertyChanged(nameof(FullName));
            }

        }
    }
}
