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
    public class EmployeeRolesController : BaseCRUDController<EmployeeRolesModel, object, 
        EmployeeRolesInsertUpdateRequest, EmployeeRolesInsertUpdateRequest>
    {
        public EmployeeRolesController(IBaseCRUDService<EmployeeRolesModel, object, 
            EmployeeRolesInsertUpdateRequest, EmployeeRolesInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
