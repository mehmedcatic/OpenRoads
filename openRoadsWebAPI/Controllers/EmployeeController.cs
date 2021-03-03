using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Helpers;
using openRoadsWebAPI.Service;

namespace openRoadsWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController :  ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }


        [HttpGet]
        public List<EmployeeModel> Get([FromQuery] EmployeeSearchRequest search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public EmployeeModel GetById(int id)
        {
            return _service.GetById(id);
        }


        [Authorize(Roles = HelperClass.adminRole)]
        [HttpPost]
        public EmployeeModel Insert(EmployeeInsertUpdateRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = HelperClass.adminRole)]
        [HttpPut("{id}")]
        public EmployeeModel Update(int id, [FromBody] EmployeeInsertUpdateRequest request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = HelperClass.adminRole)]
        [HttpDelete("{id}")]
        public EmployeeModel Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
