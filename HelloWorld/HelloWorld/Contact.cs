using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

         [PrimaryKey,AutoIncrement]
         public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }
    }
}
