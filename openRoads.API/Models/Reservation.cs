using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public float Price { get; set; }
        public DateTime CreationDate { get; set; }
        public string AdditionalInfo { get; set; }
        public bool Canceled { get; set; }
        public bool Active { get; set; }


        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }

        [ForeignKey("InsuranceId")]
        public Insurance Insurance { get; set; }
        public int InsuranceId { get; set; }
    }
}
