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
    public class InsuranceController : BaseCRUDController<InsuranceModel, object, 
        InsuranceInsertUpdateRequest, InsuranceInsertUpdateRequest>
    {
        public InsuranceController(IBaseCRUDService<InsuranceModel, object, 
            InsuranceInsertUpdateRequest, InsuranceInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
