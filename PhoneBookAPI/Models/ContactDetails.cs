using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models
{
    public class ContactDetails
    {
        [Key]
        public int ContactID { get; set; }
        public string Name { get; set; }
        [Column(TypeName ="nvarchar(10)")]
        public string ContactNumber { get; set; }
    }
}
