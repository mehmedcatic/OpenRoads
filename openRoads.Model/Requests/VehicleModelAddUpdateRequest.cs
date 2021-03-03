using System;
using System.Collections.Generic;
using System.Text;

namespace openRoads.Model.Requests
{
    public class VehicleModelAddUpdateRequest
    {
        public string Name { get; set; }
        public int? VehicleManufacturerId { get; set; }
    }
}
