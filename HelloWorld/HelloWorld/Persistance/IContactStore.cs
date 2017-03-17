using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld;
using System.Collections.ObjectModel;

namespace HelloWorld.Persistance
{
    interface IContactStore
    {

        Task<IEnumerable<Contact>> getContactsAsync();
        Task<Contact> getContactAsync(int id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Contact contact);
    }
}
