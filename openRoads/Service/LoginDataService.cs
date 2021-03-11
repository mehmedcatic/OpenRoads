using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Service
{
    public class LoginDataService : BaseCRUDService<LoginDataModel, object, LoginData, LoginDataInsertUpdateRequest, LoginDataInsertUpdateRequest>
    {
        public LoginDataService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        
    }
}
