using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDetailsContext _context;
        private readonly ILogger<ContactRepository> _logger;

        public ContactRepository(ContactDetailsContext context, ILogger<ContactRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }


        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

       

        public async Task<ContactDetails[]> GetAllContactsAsync()
        {
            _logger.LogInformation($"Getting all Contacts");
            var query = _context.contactDetails
                         .OrderBy(t => t.Name);

            return await query.ToArrayAsync();
        }

        
        
       

        public async Task<ContactDetails> GetContactByNameAsync(string name)
        {
            _logger.LogInformation($"Getting all contacts by name");

            var query = _context.contactDetails
              .Where(t => t.Name == name);

            return await query.FirstOrDefaultAsync();
        }

       
    }
}
