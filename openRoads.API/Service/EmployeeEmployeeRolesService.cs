using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using openRoads.Model;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Service
{
    public class EmployeeEmployeeRolesService : BaseService<EmployeeEmployeeRolesModel, object, EmployeeEmployeeRoles>
    {
        public EmployeeEmployeeRolesService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override EmployeeEmployeeRolesModel GetById(int id)
        {
            return _mapper.Map<EmployeeEmployeeRolesModel>(
                _context.EmployeeEmployeeRoles.FirstOrDefault(x => x.EmployeeId == id));
        }
    }
}
