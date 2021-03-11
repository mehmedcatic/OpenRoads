using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public byte[] ProfilePicture { get; set; }
        public byte[] ProfilePictureThumb { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
