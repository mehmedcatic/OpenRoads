using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Service;

namespace openRoadsWebAPI.Controllers
{
    public class VehicleManufacturerController : BaseCRUDController<VehicleManufacturerModel, object, 
        VehicleReferenceTableAddUpdateRequest, VehicleReferenceTableAddUpdateRequest>
    {
        public VehicleManufacturerController(IBaseCRUDService<VehicleManufacturerModel, object, 
            VehicleReferenceTableAddUpdateRequest, VehicleReferenceTableAddUpdateRequest> service) : base(service)
        {
        }
    }
}
