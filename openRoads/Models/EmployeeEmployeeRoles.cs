using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class EmployeeEmployeeRoles
    {
        public int EmployeeEmployeeRolesId { get; set; }
        public DateTime ChangeDate { get; set; }


        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeRolesId")]
        public EmployeeRoles EmployeeRoles { get; set; }
        public int EmployeeRolesId { get; set; }
    }
}
