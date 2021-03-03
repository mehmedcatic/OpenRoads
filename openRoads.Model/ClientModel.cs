using System;
using System.Collections.Generic;
using System.Text;

namespace openRoads.Model
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public int PersonId { get; set; }
    }
}
