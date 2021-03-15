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
    public class RatingService : BaseCRUDService<RatingModel, RatingSearchRequest, Rating, RatingInsertUpdateRequest, RatingInsertUpdateRequest>
    {
        public RatingService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override RatingModel GetById(int id)
        {
            var rating = _context.Rating.FirstOrDefault(x => x.ReservationId == id);

            if (rating != null)
                return _mapper.Map<RatingModel>(rating);

            return null;
        }
        
    }
}
