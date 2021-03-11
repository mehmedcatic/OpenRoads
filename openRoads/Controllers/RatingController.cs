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
    public class RatingController : BaseCRUDController<RatingModel, RatingSearchRequest, RatingInsertUpdateRequest, RatingInsertUpdateRequest>
    {
        public RatingController(IBaseCRUDService<RatingModel, RatingSearchRequest, RatingInsertUpdateRequest, 
            RatingInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
