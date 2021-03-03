using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Helpers;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Service
{
    public class BranchService : BaseCRUDService<BranchModel, BranchSearchRequest, Branch, BranchInsertUpdateRequest, BranchInsertUpdateRequest>
    {
        public BranchService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override List<BranchModel> Get(BranchSearchRequest search)
        {
            var query = _context.Branch.Where(x => x.Active == true).ToList();
            var countries = _context.Country.ToList();

            List<Branch> branches = new List<Branch>();

            if (search.CountryId.HasValue)
            {
                foreach (var x in query)
                {
                    if(x.CountryId == search.CountryId)
                        branches.Add(x);
                }

                return _mapper.Map<List<BranchModel>>(branches);
            }

            return _mapper.Map<List<BranchModel>>(query);
        }

        public override BranchModel Delete(int id)
        {
            var entity = _context.Branch.FirstOrDefault(x => x.BranchId == id);

            if (entity != null)
            {
                entity.Active = false;
                _context.SaveChanges();
            }

            return _mapper.Map<BranchModel>(entity);
        }

    }
}
