using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models
{
    public class ContactDetailsContext :DbContext
    {
        public ContactDetailsContext(DbContextOptions<ContactDetailsContext>options):base(options)
        {

        }
        public DbSet<ContactDetails> contactDetails { get; set; }
    }
}
