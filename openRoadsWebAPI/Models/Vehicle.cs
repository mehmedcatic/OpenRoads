using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int ManufacturedYear { get; set; }
        public int PowerInHp { get; set; }
        public int DoorsCount { get; set; }
        public int SeatsCount { get; set; }
        public float PriceByDay { get; set; }
        public string RegistrationNumber { get; set; }
        public byte[] Picture { get; set; }
        public byte[] PictureThumb { get; set; }
        public bool Available { get; set; }
        public bool Active { get; set; }



        [ForeignKey("VehicleTypeId")]
        public VehicleType VehicleType { get; set; }
        public int VehicleTypeId { get; set; }

        [ForeignKey("VehicleCategoryId")]
        public VehicleCategory VehicleCategory { get; set; }
        public int VehicleCategoryId { get; set; }

        [ForeignKey("VehicleModelId")]
        public VehicleModel VehicleModel { get; set; }
        public int VehicleModelId { get; set; }

        [ForeignKey("VehicleFuelTypeId")]
        public VehicleFuelType VehicleFuelType { get; set; }
        public int VehicleFuelTypeId { get; set; }

        [ForeignKey("VehicleTransmissionTypeId")]
        public VehicleTransmissionType VehicleTransmissionType { get; set; }
        public int VehicleTransmissionTypeId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
    }
}
