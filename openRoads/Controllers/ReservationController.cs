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
    public class ReservationController : BaseCRUDController<ReservationModel, ReservationSearchRequest, 
        ReservationInsertUpdateRequest, ReservationInsertUpdateRequest>
    {
        public ReservationController(IBaseCRUDService<ReservationModel, ReservationSearchRequest, 
            ReservationInsertUpdateRequest, ReservationInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
