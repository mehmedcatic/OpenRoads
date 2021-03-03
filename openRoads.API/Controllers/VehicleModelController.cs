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
    public class VehicleModelController : BaseCRUDController<VehicleModelModel, VehicleModelSearchRequest, 
        VehicleModelAddUpdateRequest, VehicleModelAddUpdateRequest>
    {
        public VehicleModelController(IBaseCRUDService<VehicleModelModel, VehicleModelSearchRequest, 
            VehicleModelAddUpdateRequest, VehicleModelAddUpdateRequest> service) : base(service)
        {
        }
    }
}
