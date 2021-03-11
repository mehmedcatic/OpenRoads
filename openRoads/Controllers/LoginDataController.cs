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
    public class LoginDataController : BaseCRUDController<LoginDataModel, object, LoginDataInsertUpdateRequest, LoginDataInsertUpdateRequest>
    {
        public LoginDataController(IBaseCRUDService<LoginDataModel, object, LoginDataInsertUpdateRequest, 
            LoginDataInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
