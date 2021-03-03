using System;
using System.Collections.Generic;
using System.Text;

namespace openRoads.Model.Requests
{
    public class EmployeeSearchRequest
    {
        public int? BranchId { get; set; }
        public int? EmployeeRolesId { get; set; }
    }
}
