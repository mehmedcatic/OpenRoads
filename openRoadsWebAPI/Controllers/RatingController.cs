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
    public class RatingController : BaseController<RatingModel, RatingSearchRequest>
    {
        public RatingController(IBaseService<RatingModel, RatingSearchRequest> service) : base(service)
        {
        }
    }
}
