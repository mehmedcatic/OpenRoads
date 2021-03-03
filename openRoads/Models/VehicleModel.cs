using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class VehicleModel
    {
        public int VehicleModelId { get; set; }
        public string Name { get; set; }

        [ForeignKey("VehicleManufacturerId")]
        public VehicleManufacturer VehicleManufacturer { get; set; }
        public int VehicleManufacturerId { get; set; }
    }
}
