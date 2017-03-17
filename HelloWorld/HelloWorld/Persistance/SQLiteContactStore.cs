using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Persistance
{
    class SQLiteContactStore : IContactStore
    {

        private SQLiteAsyncConnection _connection;

        public SQLiteContactStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Contact>();
        }
        public async Task AddContactAsync(Contact contact)
        {
             await _connection.InsertAsync(contact);
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            await _connection.DeleteAsync(contact);
        }

        public async Task<Contact> getContactAsync(int id)
        {
            return await _connection.FindAsync<Contact>(id);
        }

        public async Task<IEnumerable<Contact>> getContactsAsync()
        {
            return await _connection.Table<Contact>().ToListAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _connection.UpdateAsync(contact);
        }
    }
}
