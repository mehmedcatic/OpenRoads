using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


        [ForeignKey("LoginDataId")] 
        public LoginData LoginData { get; set; }
        public int LoginDataId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }

    }
}
