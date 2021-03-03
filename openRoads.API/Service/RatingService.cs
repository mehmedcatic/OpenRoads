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
    public class RatingService : BaseService<RatingModel, RatingSearchRequest, Rating>
    {
        public RatingService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        //public override List<BranchModel> Get(BranchSearchRequest search)
        //{
        //    var query = _context.Set<Branch>().AsQueryable();

        //    if (search?.VrstaId.HasValue == true)
        //    {
        //        query = query.Where(x => x.VrstaId == search.VrstaId);
        //    }

        //    query = query.OrderBy(x => x.Naziv);

        //    var list = query.ToList();

        //    return _mapper.Map<List<BranchModel>>(list);
        //}
    }
}
