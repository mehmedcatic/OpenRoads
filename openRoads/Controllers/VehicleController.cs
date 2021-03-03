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
    public class VehicleController : BaseCRUDController<VehicleModel, VehicleSearchRequest, 
        VehicleInsertUpdateRequest, VehicleInsertUpdateRequest>
    {
        public VehicleController(IBaseCRUDService<VehicleModel, VehicleSearchRequest, 
            VehicleInsertUpdateRequest, VehicleInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
