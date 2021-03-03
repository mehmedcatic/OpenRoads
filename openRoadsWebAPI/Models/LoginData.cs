using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class LoginData
    {
        public int LoginDataId { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
