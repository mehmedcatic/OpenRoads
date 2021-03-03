using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int RatingInt { get; set; }
        public string RatingString { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }


        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
    }
}
