using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using openRoads.Model;
using openRoadsWebAPI.Service;

namespace openRoadsWebAPI.Controllers
{
    public class EmployeeEmployeeRolesController : BaseController<EmployeeEmployeeRolesModel, object>
    {
        public EmployeeEmployeeRolesController(IBaseService<EmployeeEmployeeRolesModel, object> service) : base(service)
        {
        }
    }
}
