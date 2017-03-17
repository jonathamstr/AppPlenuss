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

        private Contact contacto;
        public int id {
            get { return contacto.Id
                    ; }
            set {
                contacto.id = value;
            } }
        
        
        public string fullName
        {
            get { return contacto.fullName; }
            set { contacto.fullName = value; }
        }

        public string Phone { get { return contacto.Phone; }
            set { } }
        public string Email { get; set; }
        public Boolean blocked { get; set; }

        public string firstName
        {
            get { return firstName; }
            set
            {
                SetValue(ref _firstName, value);

                SetValue(ref fullName, firstName + " " + lastName, nameof(fullName));

            }
        }

        private string _firstName;

        public string lastName
        {
            get { return _lastName; }
            set
            {
                SetValue(ref _lastName, value);

                SetValue(ref fullName, firstName + " " + lastName, nameof(fullName));
            }

        }
    }
}
