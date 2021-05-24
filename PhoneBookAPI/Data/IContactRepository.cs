using PhoneBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Data
{
    public interface IContactRepository
    {
        void Add<T>(T entity) where T : class;
  
        Task<bool> SaveChangesAsync();

        Task<ContactDetails> GetContactByNameAsync(string name);
        Task<ContactDetails[]> GetAllContactsAsync();
    }
}
